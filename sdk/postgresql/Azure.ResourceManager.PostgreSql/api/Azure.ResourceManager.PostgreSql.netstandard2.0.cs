namespace Azure.ResourceManager.PostgreSql
{
    public partial class AzureResourceManagerPostgreSqlContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPostgreSqlContext() { }
        public static Azure.ResourceManager.PostgreSql.AzureResourceManagerPostgreSqlContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlConfigurationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>
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
        Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>
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
        Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>
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
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlPrivateLinkResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerAdministratorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>
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
        Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerKeyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>
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
        Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>
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
        Azure.ResourceManager.PostgreSql.PostgreSqlServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlServerSecurityAlertPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlVirtualNetworkRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>
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
        Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.PostgreSqlVirtualNetworkRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource GetPostgreSqlFlexibleServersPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource GetPostgreSqlLtrServerBackupOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource GetPostgreSqlMigrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource GetServerThreatProtectionSettingsModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource GetVirtualEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>
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
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServerBackupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerBackupResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerConfigurationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica Replica { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? State { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage Storage { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? StorageSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>
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
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>
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
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServerResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent> CheckPostgreSqlMigrationNameAvailability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>> CheckPostgreSqlMigrationNameAvailabilityAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile> GetPostgreSqlFlexibleServerLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile> GetPostgreSqlFlexibleServerLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> GetPostgreSqlFlexibleServersPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>> GetPostgreSqlFlexibleServersPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionCollection GetPostgreSqlFlexibleServersPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> GetPostgreSqlFlexibleServersPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>> GetPostgreSqlFlexibleServersPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceCollection GetPostgreSqlFlexibleServersPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> GetPostgreSqlLtrServerBackupOperation(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>> GetPostgreSqlLtrServerBackupOperationAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationCollection GetPostgreSqlLtrServerBackupOperations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> GetPostgreSqlMigration(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> GetPostgreSqlMigrationAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationCollection GetPostgreSqlMigrations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> GetServerCapabilities(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties> GetServerCapabilitiesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> GetServerThreatProtectionSettingsModel(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>> GetServerThreatProtectionSettingsModelAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelCollection GetServerThreatProtectionSettingsModels() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> GetVirtualEndpointResource(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> GetVirtualEndpointResourceAsync(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceCollection GetVirtualEndpointResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult> StartLtrBackupFlexibleServer(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>> StartLtrBackupFlexibleServerAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult> TriggerLtrPreBackupFlexibleServer(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>> TriggerLtrPreBackupFlexibleServerAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServersPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServersPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServersPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>
    {
        public PostgreSqlFlexibleServersPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServersPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServersPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServersPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlFlexibleServersPrivateLinkResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServersPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlFlexibleServersPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlFlexibleServersPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>
    {
        public PostgreSqlFlexibleServersPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlLtrServerBackupOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlLtrServerBackupOperationCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlLtrServerBackupOperationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>
    {
        public PostgreSqlLtrServerBackupOperationData() { }
        public string BackupMetadata { get { throw null; } set { } }
        public string BackupName { get { throw null; } set { } }
        public long? DatasourceSizeInBytes { get { throw null; } set { } }
        public long? DataTransferredInBytes { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public double? PercentComplete { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus? Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlLtrServerBackupOperationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlLtrServerBackupOperationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlMigrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>, System.Collections.IEnumerable
    {
        protected PostgreSqlMigrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string migrationName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string migrationName, Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> Get(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> GetAll(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter? migrationListFilter = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> GetAllAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter? migrationListFilter = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> GetAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> GetIfExists(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> GetIfExistsAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PostgreSqlMigrationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>
    {
        public PostgreSqlMigrationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel? Cancel { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus CurrentStatus { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToCancelMigrationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToMigrate { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToTriggerCutoverOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum? MigrateRoles { get { throw null; } set { } }
        public string MigrationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigrationInstanceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode? MigrationMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption? MigrationOption { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowEndTimeInUtc { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowStartTimeInUtc { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget? OverwriteDbsInTarget { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters SecretParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb? SetupLogicalReplicationOnSourceDbIfNeeded { get { throw null; } set { } }
        public string SourceDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata SourceDbServerMetadata { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceDbServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType? SourceType { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode? SslMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration? StartDataMigration { get { throw null; } set { } }
        public string TargetDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata TargetDbServerMetadata { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetDbServerResourceId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover? TriggerCutover { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlMigrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PostgreSqlMigrationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetDbServerName, string migrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource> Update(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource>> UpdateAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ServerThreatProtectionSettingsModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>, System.Collections.IEnumerable
    {
        protected ServerThreatProtectionSettingsModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> Get(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>> GetAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> GetIfExists(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>> GetIfExistsAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ServerThreatProtectionSettingsModelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>
    {
        public ServerThreatProtectionSettingsModelData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerThreatProtectionSettingsModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ServerThreatProtectionSettingsModelResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEndpointResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualEndpointResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>, System.Collections.IEnumerable
    {
        protected VirtualEndpointResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualEndpointName, Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualEndpointName, Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> Get(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> GetAsync(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> GetIfExists(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> GetIfExistsAsync(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualEndpointResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>
    {
        public VirtualEndpointResourceData() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualEndpoints { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource GetPostgreSqlFlexibleServersPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationResource GetPostgreSqlLtrServerBackupOperationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationResource GetPostgreSqlMigrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelResource GetServerThreatProtectionSettingsModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource GetVirtualEndpointResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
    public static partial class ArmPostgreSqlFlexibleServersModelFactory
    {
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus DbLevelValidationStatus(string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem> summary = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus DbMigrationStatus(string databaseName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState? migrationState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState?), string migrationOperation = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), int? fullLoadQueuedTables = default(int?), int? fullLoadErroredTables = default(int?), int? fullLoadLoadingTables = default(int?), int? fullLoadCompletedTables = default(int?), int? cdcUpdateCounter = default(int?), int? cdcDeleteCounter = default(int?), int? cdcInsertCounter = default(int?), int? appliedChanges = default(int?), int? incomingChanges = default(int?), int? latency = default(int?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability PostgreSqlBaseCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent PostgreSqlCheckMigrationNameAvailabilityContent(string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), bool? isNameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerActiveDirectoryAdministratorData PostgreSqlFlexibleServerActiveDirectoryAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? principalType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType?), string principalName = null, System.Guid? objectId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerBackupData PostgreSqlFlexibleServerBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin? backupType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string source = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties PostgreSqlFlexibleServerBackupProperties(int? backupRetentionDays = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum? geoRedundantBackup = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoRedundantBackupEnum?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties PostgreSqlFlexibleServerCapabilityProperties(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> supportedServerEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported? supportFastProvisioning = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported? geoBackupSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported? zoneRedundantHaSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported? zoneRedundantHaAndGeoBackupSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported? storageAutoGrowthSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported? onlineResizeSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted? restricted = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties PostgreSqlFlexibleServerCapabilityProperties(string zone = null, System.Collections.Generic.IEnumerable<string> supportedHAModes = null, bool? isGeoBackupSupported = default(bool?), bool? isZoneRedundantHASupported = default(bool?), bool? isZoneRedundantHAAndGeoBackupSupported = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> supportedFlexibleServerEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability> supportedHyperscaleNodeEditions = null, bool? fastProvisioningSupported = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData PostgreSqlFlexibleServerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType? dataType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType?), string allowedValues = null, string source = null, bool? isDynamicConfig = default(bool?), bool? isReadOnly = default(bool?), bool? isConfigPendingRestart = default(bool?), string unit = null, string documentationLink = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku sku = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity identity = null, string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? version = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion?), string minorVersion = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState?), string fullyQualifiedDomainName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage storage = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig authConfig = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption dataEncryption = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties backup = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork network = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability highAvailability = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow = null, Azure.Core.ResourceIdentifier sourceServerResourceId = null, System.DateTimeOffset? pointInTimeUtc = default(System.DateTimeOffset?), string availabilityZone = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? replicationRole = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole?), int? replicaCapacity = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica replica = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? createMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku sku, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity identity, string administratorLogin, string administratorLoginPassword, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? version, string minorVersion, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? state, string fullyQualifiedDomainName, int? storageSizeInGB, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig authConfig, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption dataEncryption, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties backup, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork network, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability highAvailability, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow, Azure.Core.ResourceIdentifier sourceServerResourceId, System.DateTimeOffset? pointInTimeUtc, string availabilityZone, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? replicationRole, int? replicaCapacity, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? createMode) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData PostgreSqlFlexibleServerDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage PostgreSqlFlexibleServerDelegatedSubnetUsage(string subnetName = null, long? usage = default(long?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability PostgreSqlFlexibleServerEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, string defaultSkuName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability> supportedServerSkus = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability PostgreSqlFlexibleServerEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability PostgreSqlFlexibleServerFastProvisioningEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string supportedTier = null, string supportedSku = null, long? supportedStorageGb = default(long?), string supportedServerVersions = null, int? serverCount = default(int?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability PostgreSqlFlexibleServerFastProvisioningEditionCapability(string supportedSku = null, long? supportedStorageGb = default(long?), string supportedServerVersions = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData PostgreSqlFlexibleServerFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability PostgreSqlFlexibleServerHighAvailability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? mode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState?), string standbyAvailabilityZone = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability PostgreSqlFlexibleServerHyperscaleNodeEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability> supportedNodeTypes = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile PostgreSqlFlexibleServerLogFile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), long? sizeInKb = default(long?), string typePropertiesType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult PostgreSqlFlexibleServerLtrBackupResult(long? datasourceSizeInBytes = default(long?), long? dataTransferredInBytes = default(long?), string backupName = null, string backupMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult PostgreSqlFlexibleServerLtrPreBackupResult(int numberOfContainers = 0) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent PostgreSqlFlexibleServerNameAvailabilityContent(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse PostgreSqlFlexibleServerNameAvailabilityResponse(bool? isNameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResult PostgreSqlFlexibleServerNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason?), string message = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork PostgreSqlFlexibleServerNetwork(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState?), Azure.Core.ResourceIdentifier delegatedSubnetResourceId = null, Azure.Core.ResourceIdentifier privateDnsZoneArmResourceId = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability PostgreSqlFlexibleServerNodeTypeCapability(string name = null, string nodeType = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability PostgreSqlFlexibleServerServerVersionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, System.Collections.Generic.IEnumerable<string> supportedVersionsToUpgrade = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability PostgreSqlFlexibleServerServerVersionCapability(string name = null, System.Collections.Generic.IEnumerable<string> supportedVersionsToUpgrade = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability> supportedVCores = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability PostgreSqlFlexibleServerSkuCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, int? vCores = default(int?), int? supportedIops = default(int?), long? supportedMemoryPerVcoreMb = default(long?), System.Collections.Generic.IEnumerable<string> supportedZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode> supportedHaMode = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData PostgreSqlFlexibleServersPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData PostgreSqlFlexibleServersPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica PostgreSqlFlexibleServersReplica(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? role = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole?), int? capacity = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState? replicationState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode? promoteMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption? promoteOption = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku PostgreSqlFlexibleServersServerSku(string name = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier? tier = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability PostgreSqlFlexibleServerStorageCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, long? supportedIops = default(long?), int? supportedMaximumIops = default(int?), long? storageSizeInMB = default(long?), long? maximumStorageSizeMb = default(long?), int? supportedThroughput = default(int?), int? supportedMaximumThroughput = default(int?), string defaultIopsTier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> supportedIopsTiers = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability PostgreSqlFlexibleServerStorageCapability(string name = null, long? supportedIops = default(long?), long? storageSizeInMB = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> supportedUpgradableTierList = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability PostgreSqlFlexibleServerStorageEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, long? defaultStorageSizeMb = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> supportedStorageCapabilities = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability PostgreSqlFlexibleServerStorageEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> supportedStorageCapabilities = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability PostgreSqlFlexibleServerStorageTierCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, long? iops = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability PostgreSqlFlexibleServerStorageTierCapability(string name = null, string tierName = null, long? iops = default(long?), bool? isBaseline = default(bool?), string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails PostgreSqlFlexibleServersValidationDetails(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState?), System.DateTimeOffset? validationStartTimeInUtc = default(System.DateTimeOffset?), System.DateTimeOffset? validationEndTimeInUtc = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem> serverLevelValidationDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus> dbLevelValidationDetails = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage PostgreSqlFlexibleServersValidationMessage(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity PostgreSqlFlexibleServerUserAssignedIdentity(System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> userAssignedIdentities = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType identityType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability PostgreSqlFlexibleServerVCoreCapability(string name = null, long? vCores = default(long?), long? supportedIops = default(long?), long? supportedMemoryPerVCoreInMB = default(long?), string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage> delegatedSubnetsUsage = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string subscriptionId = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlLtrServerBackupOperationData PostgreSqlLtrServerBackupOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? datasourceSizeInBytes = default(long?), long? dataTransferredInBytes = default(long?), string backupName = null, string backupMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlMigrationData PostgreSqlMigrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string migrationId = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus currentStatus = null, Azure.Core.ResourceIdentifier migrationInstanceResourceId = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode? migrationMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption? migrationOption = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType? sourceType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode? sslMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata sourceDbServerMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata targetDbServerMetadata = null, Azure.Core.ResourceIdentifier sourceDbServerResourceId = null, string sourceDbServerFullyQualifiedDomainName = null, Azure.Core.ResourceIdentifier targetDbServerResourceId = null, string targetDbServerFullyQualifiedDomainName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters secretParameters = null, System.Collections.Generic.IEnumerable<string> dbsToMigrate = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb? setupLogicalReplicationOnSourceDbIfNeeded = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget? overwriteDbsInTarget = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget?), System.DateTimeOffset? migrationWindowStartTimeInUtc = default(System.DateTimeOffset?), System.DateTimeOffset? migrationWindowEndTimeInUtc = default(System.DateTimeOffset?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum? migrateRoles = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration? startDataMigration = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover? triggerCutover = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover?), System.Collections.Generic.IEnumerable<string> dbsToTriggerCutoverOn = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel? cancel = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel?), System.Collections.Generic.IEnumerable<string> dbsToCancelMigrationOn = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus PostgreSqlMigrationStatus(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState?), string error = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails currentSubStateDetails = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails PostgreSqlMigrationSubStateDetails(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState? currentSubState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus> dbDetails = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails validationDetails = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata PostgreSqlServerMetadata(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string version = null, int? storageMb = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku sku = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.ServerThreatProtectionSettingsModelData ServerThreatProtectionSettingsModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem ValidationSummaryItem(string validationSummaryItemType = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage> messages = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResourceData VirtualEndpointResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? endpointType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType?), System.Collections.Generic.IEnumerable<string> members = null, System.Collections.Generic.IEnumerable<string> virtualEndpoints = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch VirtualEndpointResourcePatch(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? endpointType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType?), System.Collections.Generic.IEnumerable<string> members = null, System.Collections.Generic.IEnumerable<string> virtualEndpoints = null) { throw null; }
    }
    public partial class DbLevelValidationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus>
    {
        internal DbLevelValidationStatus() { }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem> Summary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DbMigrationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus>
    {
        internal DbMigrationStatus() { }
        public int? AppliedChanges { get { throw null; } }
        public int? CdcDeleteCounter { get { throw null; } }
        public int? CdcInsertCounter { get { throw null; } }
        public int? CdcUpdateCounter { get { throw null; } }
        public string DatabaseName { get { throw null; } }
        public System.DateTimeOffset? EndedOn { get { throw null; } }
        public int? FullLoadCompletedTables { get { throw null; } }
        public int? FullLoadErroredTables { get { throw null; } }
        public int? FullLoadLoadingTables { get { throw null; } }
        public int? FullLoadQueuedTables { get { throw null; } }
        public int? IncomingChanges { get { throw null; } }
        public int? Latency { get { throw null; } }
        public string Message { get { throw null; } }
        public string MigrationOperation { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState? MigrationState { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? NumFullLoadCompletedTables { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? NumFullLoadErroredTables { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? NumFullLoadLoadingTables { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? NumFullLoadQueuedTables { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateRolesEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateRolesEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationDbState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationDbState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState Canceling { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState InProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState WaitingForCutoverTrigger { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDbState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationOption : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationOption(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption Migrate { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption Validate { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption ValidateAndMigrate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlBackupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent>
    {
        public PostgreSqlBackupContent(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings backupSettings) { }
        public string BackupName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlBaseCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>
    {
        internal PostgreSqlBaseCapability() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? CapabilityStatus { get { throw null; } }
        public string Reason { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlCheckMigrationNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>
    {
        public PostgreSqlCheckMigrationNameAvailabilityContent(string name, Azure.Core.ResourceType resourceType) { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason? Reason { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlCheckMigrationNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlExecutionStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlExecutionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus Running { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum PostgreSqlFlexbileServerCapabilityStatus
    {
        Visible = 0,
        Available = 1,
        Default = 2,
        Disabled = 3,
    }
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent>
    {
        public PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent() { }
        public string PrincipalName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupOrigin CustomerOnDemand { get { throw null; } }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings>
    {
        public PostgreSqlFlexibleServerBackupSettings(string backupName) { }
        public string BackupName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupStoreDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails>
    {
        public PostgreSqlFlexibleServerBackupStoreDetails(System.Collections.Generic.IEnumerable<string> sasUriList) { }
        public System.Collections.Generic.IList<string> SasUriList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerCapabilityProperties : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCapabilityProperties>
    {
        internal PostgreSqlFlexibleServerCapabilityProperties() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? FastProvisioningSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported? GeoBackupSupported { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsGeoBackupSupported { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHAAndGeoBackupSupported { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsZoneRedundantHASupported { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported? OnlineResizeSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted? Restricted { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported? StorageAutoGrowthSupported { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> SupportedFastProvisioningEditions { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAModes { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability> SupportedHyperscaleNodeEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> SupportedServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported? SupportFastProvisioning { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Zone { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported? ZoneRedundantHaAndGeoBackupSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported? ZoneRedundantHaSupported { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class PostgreSqlFlexibleServerDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>
    {
        public PostgreSqlFlexibleServerDataEncryption() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus? GeoBackupEncryptionKeyStatus { get { throw null; } set { } }
        public System.Uri GeoBackupKeyUri { get { throw null; } set { } }
        public string GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerKeyType? KeyType { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus? PrimaryEncryptionKeyStatus { get { throw null; } set { } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerEditionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability>
    {
        internal PostgreSqlFlexibleServerEditionCapability() { }
        public string DefaultSkuName { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability> SupportedServerSkus { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class PostgreSqlFlexibleServerFastProvisioningEditionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>
    {
        internal PostgreSqlFlexibleServerFastProvisioningEditionCapability() { }
        public int? ServerCount { get { throw null; } }
        public string SupportedServerVersions { get { throw null; } }
        public string SupportedSku { get { throw null; } }
        public long? SupportedStorageGb { get { throw null; } }
        public string SupportedTier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerFastProvisioningSupported : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerFastProvisioningSupported(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningSupported right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerGeoBackupSupported : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerGeoBackupSupported(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerGeoBackupSupported right) { throw null; }
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
    public partial class PostgreSqlFlexibleServerHighAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>
    {
        public PostgreSqlFlexibleServerHighAvailability() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerHyperscaleNodeEditionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>
    {
        internal PostgreSqlFlexibleServerHyperscaleNodeEditionCapability() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability> SupportedNodeTypes { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
    public partial class PostgreSqlFlexibleServerLogFile : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile>
    {
        public PostgreSqlFlexibleServerLogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public long? SizeInKb { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLogFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerLtrBackupContent : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent>
    {
        public PostgreSqlFlexibleServerLtrBackupContent(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings backupSettings, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails targetDetails) : base (default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings)) { }
        public System.Collections.Generic.IList<string> TargetDetailsSasUriList { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerLtrBackupResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>
    {
        internal PostgreSqlFlexibleServerLtrBackupResult() { }
        public string BackupMetadata { get { throw null; } }
        public string BackupName { get { throw null; } }
        public long? DatasourceSizeInBytes { get { throw null; } }
        public long? DataTransferredInBytes { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public double? PercentComplete { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrBackupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerLtrPreBackupContent : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent>
    {
        public PostgreSqlFlexibleServerLtrPreBackupContent(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings backupSettings) : base (default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerLtrPreBackupResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>
    {
        internal PostgreSqlFlexibleServerLtrPreBackupResult() { }
        public int NumberOfContainers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerMaintenanceWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow>
    {
        public PostgreSqlFlexibleServerMaintenanceWindow() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerNodeTypeCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>
    {
        internal PostgreSqlFlexibleServerNodeTypeCapability() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string NodeType { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Status { get { throw null; } }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerOnlineResizeSupported : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerOnlineResizeSupported(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerOnlineResizeSupported right) { throw null; }
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
    public partial class PostgreSqlFlexibleServerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>
    {
        public PostgreSqlFlexibleServerPatch() { }
        public string AdministratorLogin { get { throw null; } set { } }
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
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica Replica { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage Storage { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? StorageSizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
    public partial class PostgreSqlFlexibleServerRestartParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>
    {
        public PostgreSqlFlexibleServerRestartParameter() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFailoverMode? FailoverMode { get { throw null; } set { } }
        public bool? RestartWithFailover { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerServerVersionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability>
    {
        internal PostgreSqlFlexibleServerServerVersionCapability() { }
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability> SupportedVCores { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedVersionsToUpgrade { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerSkuCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability>
    {
        internal PostgreSqlFlexibleServerSkuCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHAMode> SupportedHaMode { get { throw null; } }
        public int? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVcoreMb { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedZones { get { throw null; } }
        public int? VCores { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServersPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>
    {
        public PostgreSqlFlexibleServersPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServersReplica : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica>
    {
        public PostgreSqlFlexibleServersReplica() { }
        public int? Capacity { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode? PromoteMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption? PromoteOption { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState? ReplicationState { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? Role { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServersReplicationState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServersReplicationState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState Active { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState Broken { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState Catchup { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState Reconfiguring { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServersServerSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku>
    {
        internal PostgreSqlFlexibleServersServerSku() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier? Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServersSourceType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServersSourceType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWS { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWSAurora { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWSEC2 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWSRDS { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AzureVm { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType EDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCP { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCPAlloyDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCPCloudSQL { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCPCompute { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType OnPremises { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType PostgreSQLSingleServer { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServersSslMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServersSslMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode Prefer { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode Require { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode VerifyCA { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode VerifyFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServersStorageType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServersStorageType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType PremiumLRS { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType PremiumV2LRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType right) { throw null; }
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
    public partial class PostgreSqlFlexibleServerStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>
    {
        public PostgreSqlFlexibleServerStorage() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow? AutoGrow { get { throw null; } set { } }
        public int? Iops { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType? StorageType { get { throw null; } set { } }
        public int? Throughput { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerStorageAutoGrowthSupported : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerStorageAutoGrowthSupported(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageAutoGrowthSupported right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>
    {
        internal PostgreSqlFlexibleServerStorageCapability() { }
        public string DefaultIopsTier { get { throw null; } }
        public long? MaximumStorageSizeMb { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw null; } }
        public long? StorageSizeInMB { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> SupportedIopsTiers { get { throw null; } }
        public int? SupportedMaximumIops { get { throw null; } }
        public int? SupportedMaximumThroughput { get { throw null; } }
        public int? SupportedThroughput { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> SupportedUpgradableTierList { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageEditionCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>
    {
        internal PostgreSqlFlexibleServerStorageEditionCapability() { }
        public long? DefaultStorageSizeMb { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> SupportedStorageCapabilities { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageTierCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>
    {
        internal PostgreSqlFlexibleServerStorageTierCapability() { }
        public long? Iops { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsBaseline { get { throw null; } }
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string TierName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServersValidationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails>
    {
        internal PostgreSqlFlexibleServersValidationDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus> DbLevelValidationDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem> ServerLevelValidationDetails { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? Status { get { throw null; } }
        public System.DateTimeOffset? ValidationEndTimeInUtc { get { throw null; } }
        public System.DateTimeOffset? ValidationStartTimeInUtc { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServersValidationMessage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage>
    {
        internal PostgreSqlFlexibleServersValidationMessage() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServersValidationState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServersValidationState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>
    {
        public PostgreSqlFlexibleServerUserAssignedIdentity(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType identityType) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType IdentityType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerVCoreCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability>
    {
        internal PostgreSqlFlexibleServerVCoreCapability() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Name { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Status { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? SupportedIops { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public long? SupportedMemoryPerVCoreInMB { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Sixteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver11 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver12 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver13 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver14 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVersion Ver15 { get { throw null; } }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaAndGeoBackupSupported right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerZoneRedundantHaSupported : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerZoneRedundantHaSupported(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantHaSupported right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerZoneRedundantRestricted : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerZoneRedundantRestricted(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerZoneRedundantRestricted right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlKeyStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlManagedDiskPerformanceTier : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlManagedDiskPerformanceTier(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P1 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P10 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P15 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P2 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P20 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P3 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P30 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P4 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P40 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P50 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P6 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P60 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P70 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier P80 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlManagedDiskPerformanceTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlMigrationAdminCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials>
    {
        public PostgreSqlMigrationAdminCredentials(string sourceServerPassword, string targetServerPassword) { }
        public string SourceServerPassword { get { throw null; } set { } }
        public string TargetServerPassword { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationCancel : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationCancel(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationListFilter : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationListFilter(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter Active { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter All { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationLogicalReplicationOnSourceDb : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationLogicalReplicationOnSourceDb(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode Offline { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode Online { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationNameUnavailableReason : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationOverwriteDbsInTarget : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationOverwriteDbsInTarget(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlMigrationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch>
    {
        public PostgreSqlMigrationPatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationCancel? Cancel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DbsToCancelMigrationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToMigrate { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToTriggerCutoverOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesEnum? MigrateRoles { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode? MigrationMode { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowStartTimeInUtc { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationOverwriteDbsInTarget? OverwriteDbsInTarget { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters SecretParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationLogicalReplicationOnSourceDb? SetupLogicalReplicationOnSourceDbIfNeeded { get { throw null; } set { } }
        public string SourceDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceDbServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration? StartDataMigration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover? TriggerCutover { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlMigrationSecretParameters : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters>
    {
        public PostgreSqlMigrationSecretParameters(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials adminCredentials) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationAdminCredentials AdminCredentials { get { throw null; } set { } }
        public string SourceServerUsername { get { throw null; } set { } }
        public string TargetServerUsername { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationStartDataMigration : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationStartDataMigration(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStartDataMigration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState CleaningUp { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState InProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState ValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState WaitingForUserAction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlMigrationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>
    {
        internal PostgreSqlMigrationStatus() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails CurrentSubStateDetails { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationSubState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationSubState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState CancelingRequestedDBMigrations { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState Completed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState CompletingMigration { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState MigratingData { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState PerformingPreRequisiteSteps { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState ValidationInProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState WaitingForCutoverTrigger { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState WaitingForDataMigrationScheduling { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState WaitingForDataMigrationWindow { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState WaitingForDBsToMigrateSpecification { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState WaitingForLogicalReplicationSetupRequestOnSourceDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState WaitingForTargetDBOverwriteConfirmation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlMigrationSubStateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails>
    {
        internal PostgreSqlMigrationSubStateDetails() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubState? CurrentSubState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbMigrationStatus> DbDetails { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails ValidationDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSubStateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlMigrationTriggerCutover : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationTriggerCutover(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationTriggerCutover right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlServerMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata>
    {
        internal PostgreSqlServerMetadata() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku Sku { get { throw null; } }
        public int? StorageMb { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReadReplicaPromoteMode : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReadReplicaPromoteMode(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode Standalone { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode Switchover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReplicationPromoteOption : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReplicationPromoteOption(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption Forced { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption Planned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReplicationPromoteOption right) { throw null; }
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
    public readonly partial struct ThreatProtectionName : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreatProtectionName(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ThreatProtectionState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class ValidationSummaryItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem>
    {
        internal ValidationSummaryItem() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage> Messages { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? State { get { throw null; } }
        public string ValidationSummaryItemType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEndpointResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch>
    {
        public VirtualEndpointResourcePatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualEndpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEndpointType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType right) { throw null; }
        public override string ToString() { throw null; }
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
    public static partial class ArmPostgreSqlModelFactory
    {
        public static Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData PostgreSqlConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, string dataType = null, string allowedValues = null, string source = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlDatabaseData PostgreSqlDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlFirewallRuleData PostgreSqlFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlLogFile PostgreSqlLogFile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? sizeInKB = default(long?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string logFileType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityContent PostgreSqlNameAvailabilityContent(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlNameAvailabilityResult PostgreSqlNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string reason = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierProperties PostgreSqlPerformanceTierProperties(string id = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minLargeStorageInMB = default(int?), int? maxLargeStorageInMB = default(int?), int? minStorageInMB = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives> serviceLevelObjectives = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPerformanceTierServiceLevelObjectives PostgreSqlPerformanceTierServiceLevelObjectives(string id = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minStorageInMB = default(int?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateEndpointConnectionData PostgreSqlPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlPrivateLinkResourceData PostgreSqlPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkResourceProperties PostgreSqlPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateProperty PostgreSqlPrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlRecoverableServerResourceData PostgreSqlRecoverableServerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastAvailableBackupOn = default(System.DateTimeOffset?), string serviceLevelObjective = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, string version = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerAdministratorData PostgreSqlServerAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType? administratorType = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlAdministratorType?), string loginAccountName = null, System.Guid? secureId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerCreateOrUpdateContent PostgreSqlServerCreateOrUpdateContent(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku sku = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForCreate properties = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerData PostgreSqlServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlSku sku = null, string administratorLogin = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? version = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum?), string byokEnforcement = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState? userVisibleState = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerState?), string fullyQualifiedDomainName = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile storageProfile = null, string replicationRole = null, Azure.Core.ResourceIdentifier masterServerId = null, int? replicaCapacity = default(int?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.PostgreSqlServerKeyData PostgreSqlServerKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType? serverKeyType = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerKeyType?), System.Uri uri = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnection PostgreSqlServerPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateEndpointConnectionProperties PostgreSqlServerPrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty privateLinkServiceConnectionState = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState? provisioningState = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateEndpointProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPrivateLinkServiceConnectionStateProperty PostgreSqlServerPrivateLinkServiceConnectionStateProperty(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus status = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateStatus), string description = null, Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction? actionsRequired = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPrivateLinkServiceConnectionStateRequiredAction?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForDefaultCreate PostgreSqlServerPropertiesForDefaultCreate(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? version = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile storageProfile = null, string administratorLogin = null, string administratorLoginPassword = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForGeoRestore PostgreSqlServerPropertiesForGeoRestore(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? version = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile storageProfile = null, Azure.Core.ResourceIdentifier sourceServerId = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForReplica PostgreSqlServerPropertiesForReplica(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? version = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile storageProfile = null, Azure.Core.ResourceIdentifier sourceServerId = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerPropertiesForRestore PostgreSqlServerPropertiesForRestore(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion? version = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlServerVersion?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlSslEnforcementEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlMinimalTlsVersionEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlInfrastructureEncryption?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.Models.PostgreSqlPublicNetworkAccessEnum?), Azure.ResourceManager.PostgreSql.Models.PostgreSqlStorageProfile storageProfile = null, Azure.Core.ResourceIdentifier sourceServerId = null, System.DateTimeOffset restorePointInTime = default(System.DateTimeOffset)) { throw null; }
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
    public partial class PostgreSqlConfigurationList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.Models.PostgreSqlConfigurationList>
    {
        public PostgreSqlConfigurationList() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.PostgreSql.PostgreSqlConfigurationData> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
