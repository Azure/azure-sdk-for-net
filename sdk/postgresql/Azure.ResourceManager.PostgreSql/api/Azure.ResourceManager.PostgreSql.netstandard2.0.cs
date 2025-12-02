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
    public partial class AdministratorMicrosoftEntraCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>, System.Collections.IEnumerable
    {
        protected AdministratorMicrosoftEntraCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string objectId, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> Get(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>> GetAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> GetIfExists(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>> GetIfExistsAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdministratorMicrosoftEntraData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>
    {
        public AdministratorMicrosoftEntraData() { }
        public string ObjectId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdministratorMicrosoftEntraResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdministratorMicrosoftEntraResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string objectId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AdvancedThreatProtectionSettingsModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>, System.Collections.IEnumerable
    {
        protected AdvancedThreatProtectionSettingsModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> Get(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>> GetAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> GetIfExists(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>> GetIfExistsAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvancedThreatProtectionSettingsModelData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>
    {
        public AdvancedThreatProtectionSettingsModelData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvancedThreatProtectionSettingsModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvancedThreatProtectionSettingsModelResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupAutomaticAndOnDemandCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>, System.Collections.IEnumerable
    {
        protected BackupAutomaticAndOnDemandCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupAutomaticAndOnDemandData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>
    {
        public BackupAutomaticAndOnDemandData() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType? BackupType { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupAutomaticAndOnDemandResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupAutomaticAndOnDemandResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupsLongTermRetentionOperationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>, System.Collections.IEnumerable
    {
        protected BackupsLongTermRetentionOperationCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupsLongTermRetentionOperationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>
    {
        public BackupsLongTermRetentionOperationData() { }
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
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupsLongTermRetentionOperationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupsLongTermRetentionOperationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class FlexibleServersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel> CheckGloballyNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>> CheckGloballyNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel> CheckWithLocationNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>> CheckWithLocationNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource GetAdministratorMicrosoftEntraResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource GetAdvancedThreatProtectionSettingsModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource GetBackupAutomaticAndOnDemandResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource GetBackupsLongTermRetentionOperationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability> GetCapabilitiesByLocations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability> GetCapabilitiesByLocationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource GetMigrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetPostgreSqlFlexibleServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource GetPostgreSqlFlexibleServerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource GetPostgreSqlFlexibleServerDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource GetPostgreSqlFlexibleServerFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource GetPostgreSqlFlexibleServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerCollection GetPostgreSqlFlexibleServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource GetPostgreSqlFlexibleServersPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<string> GetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<string>> GetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage> GetQuotaUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage> GetQuotaUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource GetTuningOptionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource GetVirtualEndpointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel> GetVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>> GetVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MigrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>, System.Collections.IEnumerable
    {
        protected MigrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string migrationName, Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string migrationName, Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> Get(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> GetAll(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter? migrationListFilter = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> GetAllAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter? migrationListFilter = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> GetAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> GetIfExists(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> GetIfExistsAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MigrationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>
    {
        public MigrationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel? Cancel { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus CurrentStatus { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToCancelMigrationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToMigrate { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToTriggerCutoverOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission? MigrateRoles { get { throw null; } set { } }
        public string MigrationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigrationInstanceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode? MigrationMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption? MigrationOption { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowEndTimeInUtc { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowStartTimeInUtc { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer? OverwriteDbsInTarget { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters SecretParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer? SetupLogicalReplicationOnSourceDbIfNeeded { get { throw null; } set { } }
        public string SourceDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata SourceDbServerMetadata { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceDbServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType? SourceType { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode? SslMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration? StartDataMigration { get { throw null; } set { } }
        public string TargetDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata TargetDbServerMetadata { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetDbServerResourceId { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover? TriggerCutover { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MigrationResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string migrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> Update(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> UpdateAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate configurationForUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate configurationForUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate configurationForUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate configurationForUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>
    {
        public PostgreSqlFlexibleServerData(Azure.Core.AzureLocation location) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig AuthConfig { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster Cluster { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public string MinorVersion { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public System.DateTimeOffset? PointInTimeUtc { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica Replica { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? State { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage Storage { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity UserAssignedIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion? Version { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability> CheckNameAvailabilityMigration(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability migrationNameAvailability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>> CheckNameAvailabilityMigrationAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability migrationNameAvailability, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult> CheckPrerequisitesBackupsLongTermRetention(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult>> CheckPrerequisitesBackupsLongTermRetentionAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource> GetAdministratorMicrosoftEntra(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource>> GetAdministratorMicrosoftEntraAsync(string objectId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraCollection GetAdministratorMicrosoftEntras() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource> GetAdvancedThreatProtectionSettingsModel(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource>> GetAdvancedThreatProtectionSettingsModelAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName threatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelCollection GetAdvancedThreatProtectionSettingsModels() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource> GetBackupAutomaticAndOnDemand(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource>> GetBackupAutomaticAndOnDemandAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandCollection GetBackupAutomaticAndOnDemands() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource> GetBackupsLongTermRetentionOperation(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource>> GetBackupsLongTermRetentionOperationAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationCollection GetBackupsLongTermRetentionOperations() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability> GetCapabilitiesByServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability> GetCapabilitiesByServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog> GetCapturedLogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog> GetCapturedLogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource> GetMigration(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource>> GetMigrationAsync(string migrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationCollection GetMigrations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource> GetPostgreSqlFlexibleServerConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource>> GetPostgreSqlFlexibleServerConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationCollection GetPostgreSqlFlexibleServerConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource> GetPostgreSqlFlexibleServerDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource>> GetPostgreSqlFlexibleServerDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseCollection GetPostgreSqlFlexibleServerDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource> GetPostgreSqlFlexibleServerFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource>> GetPostgreSqlFlexibleServerFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleCollection GetPostgreSqlFlexibleServerFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource> GetPostgreSqlFlexibleServersPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource>> GetPostgreSqlFlexibleServersPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionCollection GetPostgreSqlFlexibleServersPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource> GetPostgreSqlFlexibleServersPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource>> GetPostgreSqlFlexibleServersPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceCollection GetPostgreSqlFlexibleServersPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> GetTuningOption(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>> GetTuningOptionAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionCollection GetTuningOptions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> GetVirtualEndpoint(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> GetVirtualEndpointAsync(string virtualEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointCollection GetVirtualEndpoints() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerRestartParameter postgreSqlFlexibleServerRestartParameter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse> StartBackupsLongTermRetention(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>> StartBackupsLongTermRetentionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TuningOptionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>, System.Collections.IEnumerable
    {
        protected TuningOptionCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> Get(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>> GetAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> GetIfExists(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>> GetIfExistsAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TuningOptionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>
    {
        public TuningOptionData() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TuningOptionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TuningOptionResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum tuningOption) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation> GetRecommendations(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum? recommendationType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation> GetRecommendationsAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum? recommendationType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEndpointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>, System.Collections.IEnumerable
    {
        protected VirtualEndpointCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualEndpointName, Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualEndpointName, Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class VirtualEndpointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>
    {
        public VirtualEndpointData() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualEndpoints { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualEndpointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualEndpointResource() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Mocking
{
    public partial class MockablePostgreSqlFlexibleServersArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlFlexibleServersArmClient() { }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraResource GetAdministratorMicrosoftEntraResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelResource GetAdvancedThreatProtectionSettingsModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandResource GetBackupAutomaticAndOnDemandResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationResource GetBackupsLongTermRetentionOperationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationResource GetMigrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationResource GetPostgreSqlFlexibleServerConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseResource GetPostgreSqlFlexibleServerDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleResource GetPostgreSqlFlexibleServerFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource GetPostgreSqlFlexibleServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionResource GetPostgreSqlFlexibleServersPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResource GetPostgreSqlFlexibleServersPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionResource GetTuningOptionResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel> CheckGloballyNameAvailability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>> CheckGloballyNameAvailabilityAsync(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel> CheckWithLocationNameAvailability(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>> CheckWithLocationNameAvailabilityAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability> GetCapabilitiesByLocations(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability> GetCapabilitiesByLocationsAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerResource> GetPostgreSqlFlexibleServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage> GetQuotaUsages(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage> GetQuotaUsagesAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel> GetVirtualNetworkSubnetUsage(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>> GetVirtualNetworkSubnetUsageAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter postgreSqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePostgreSqlFlexibleServersTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePostgreSqlFlexibleServersTenantResource() { }
        public virtual Azure.Response<string> GetPrivateDnsZoneSuffix(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<string>> GetPrivateDnsZoneSuffixAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class AdminCredentialsForPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch>
    {
        public AdminCredentialsForPatch() { }
        public string SourceServerPassword { get { throw null; } set { } }
        public string TargetServerPassword { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdministratorMicrosoftEntraCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent>
    {
        public AdministratorMicrosoftEntraCreateOrUpdateContent() { }
        public string PrincipalName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? PrincipalType { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdministratorMicrosoftEntraCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmPostgreSqlFlexibleServersModelFactory
    {
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.AdministratorMicrosoftEntraData AdministratorMicrosoftEntraData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType? principalType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPrincipalType?), string principalName = null, string objectId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.AdvancedThreatProtectionSettingsModelData AdvancedThreatProtectionSettingsModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.BackupAutomaticAndOnDemandData BackupAutomaticAndOnDemandData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType? backupType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string source = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch BackupForPatch(int? backupRetentionDays = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup? geoRedundantBackup = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.BackupsLongTermRetentionOperationData BackupsLongTermRetentionOperationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? datasourceSizeInBytes = default(long?), long? dataTransferredInBytes = default(long?), string backupName = null, string backupMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse BackupsLongTermRetentionResponse(long? datasourceSizeInBytes = default(long?), long? dataTransferredInBytes = default(long?), string backupName = null, string backupMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlExecutionStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?), string errorCode = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability Capability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> supportedServerEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature> supportedFeatures = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport? fastProvisioningSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> supportedFastProvisioningEditions = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport? geoBackupSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport? zoneRedundantHaSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport? zoneRedundantHaAndGeoBackupSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport? storageAutoGrowthSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport? onlineResizeSupported = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted? restricted = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog CapturedLog(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), long? sizeInKb = default(long?), string typePropertiesType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate ConfigurationForUpdate(string value = null, string description = null, string defaultValue = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType? dataType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType?), string allowedValues = null, string source = null, bool? isDynamicConfig = default(bool?), bool? isReadOnly = default(bool?), bool? isConfigPendingRestart = default(bool?), string unit = null, string documentationLink = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState DatabaseMigrationState(string databaseName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState? migrationState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState?), string migrationOperation = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), int? fullLoadQueuedTables = default(int?), int? fullLoadErroredTables = default(int?), int? fullLoadLoadingTables = default(int?), int? fullLoadCompletedTables = default(int?), int? cdcUpdateCounter = default(int?), int? cdcDeleteCounter = default(int?), int? cdcInsertCounter = default(int?), int? appliedChanges = default(int?), int? incomingChanges = default(int?), int? latency = default(int?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus DbLevelValidationStatus(string databaseName = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), System.DateTimeOffset? endedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem> summary = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch HighAvailabilityForPatch(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? mode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState?), string standbyAvailabilityZone = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord ImpactRecord(string dimensionName = null, string unit = null, long? queryId = default(long?), double? absoluteValue = default(double?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.MigrationData MigrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string migrationId = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus currentStatus = null, Azure.Core.ResourceIdentifier migrationInstanceResourceId = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode? migrationMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption? migrationOption = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType? sourceType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode? sslMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSslMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata sourceDbServerMetadata = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata targetDbServerMetadata = null, Azure.Core.ResourceIdentifier sourceDbServerResourceId = null, string sourceDbServerFullyQualifiedDomainName = null, Azure.Core.ResourceIdentifier targetDbServerResourceId = null, string targetDbServerFullyQualifiedDomainName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationSecretParameters secretParameters = null, System.Collections.Generic.IEnumerable<string> dbsToMigrate = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer? setupLogicalReplicationOnSourceDbIfNeeded = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer? overwriteDbsInTarget = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer?), System.DateTimeOffset? migrationWindowStartTimeInUtc = default(System.DateTimeOffset?), System.DateTimeOffset? migrationWindowEndTimeInUtc = default(System.DateTimeOffset?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission? migrateRoles = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration? startDataMigration = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover? triggerCutover = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover?), System.Collections.Generic.IEnumerable<string> dbsToTriggerCutoverOn = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel? cancel = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel?), System.Collections.Generic.IEnumerable<string> dbsToCancelMigrationOn = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability MigrationNameAvailability(string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), bool? nameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails MigrationSubstateDetails(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate? currentSubState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate?), System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState> dbDetails = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails validationDetails = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel NameAvailabilityModel(bool? isNameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason?), string message = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty NameProperty(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation ObjectRecommendation(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, System.DateTimeOffset? initialRecommendedOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastRecommendedOn = default(System.DateTimeOffset?), int? timesRecommended = default(int?), System.Collections.Generic.IEnumerable<long> improvedQueryIds = null, string recommendationReason = null, string currentState = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum? recommendationType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails implementationDetails = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload analyzedWorkload = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord> estimatedImpact = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails details = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails ObjectRecommendationDetails(string databaseName = null, string schema = null, string table = null, string indexType = null, string indexName = null, System.Collections.Generic.IEnumerable<string> indexColumns = null, System.Collections.Generic.IEnumerable<string> includedColumns = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability PostgreSqlBaseCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties PostgreSqlFlexibleServerBackupProperties(int? backupRetentionDays = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup? geoRedundantBackup = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerConfigurationData PostgreSqlFlexibleServerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType? dataType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType?), string allowedValues = null, string source = null, bool? isDynamicConfig = default(bool?), bool? isReadOnly = default(bool?), bool? isConfigPendingRestart = default(bool?), string unit = null, string documentationLink = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion? version = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion?), string minorVersion = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState?), string fullyQualifiedDomainName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage storage = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig authConfig = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption dataEncryption = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties backup = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork network = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability highAvailability = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow = null, Azure.Core.ResourceIdentifier sourceServerResourceId = null, System.DateTimeOffset? pointInTimeUtc = default(System.DateTimeOffset?), string availabilityZone = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? replicationRole = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole?), int? replicaCapacity = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica replica = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? createMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster cluster = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerData PostgreSqlFlexibleServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSku sku = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerUserAssignedIdentity identity = null, string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion? version = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion?), string minorVersion = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState?), string fullyQualifiedDomainName = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage storage = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig authConfig = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption dataEncryption = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties backup = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork network = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability highAvailability = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerMaintenanceWindow maintenanceWindow = null, Azure.Core.ResourceIdentifier sourceServerResourceId = null, System.DateTimeOffset? pointInTimeUtc = default(System.DateTimeOffset?), string availabilityZone = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? replicationRole = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole?), int? replicaCapacity = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica replica = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode? createMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster cluster = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerDatabaseData PostgreSqlFlexibleServerDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage PostgreSqlFlexibleServerDelegatedSubnetUsage(string subnetName = null, long? usage = default(long?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability PostgreSqlFlexibleServerEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, string defaultSkuName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability> supportedServerSkus = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability PostgreSqlFlexibleServerEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability PostgreSqlFlexibleServerFastProvisioningEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string supportedTier = null, string supportedSku = null, long? supportedStorageGb = default(long?), string supportedServerVersions = null, int? serverCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability PostgreSqlFlexibleServerFastProvisioningEditionCapability(string supportedSku = null, long? supportedStorageGb = default(long?), string supportedServerVersions = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServerFirewallRuleData PostgreSqlFlexibleServerFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability PostgreSqlFlexibleServerHighAvailability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? mode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState?), string standbyAvailabilityZone = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHyperscaleNodeEditionCapability PostgreSqlFlexibleServerHyperscaleNodeEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability> supportedNodeTypes = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerLtrPreBackupResult PostgreSqlFlexibleServerLtrPreBackupResult(int numberOfContainers = 0) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityContent PostgreSqlFlexibleServerNameAvailabilityContent(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse PostgreSqlFlexibleServerNameAvailabilityResponse(bool? isNameAvailable = default(bool?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason? reason = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason?), string message = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork PostgreSqlFlexibleServerNetwork(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState? publicNetworkAccess = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPublicNetworkAccessState?), Azure.Core.ResourceIdentifier delegatedSubnetResourceId = null, Azure.Core.ResourceIdentifier privateDnsZoneArmResourceId = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNodeTypeCapability PostgreSqlFlexibleServerNodeTypeCapability(string name = null, string nodeType = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability PostgreSqlFlexibleServerServerVersionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, System.Collections.Generic.IEnumerable<string> supportedVersionsToUpgrade = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature> supportedFeatures = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuCapability PostgreSqlFlexibleServerSkuCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, int? vCores = default(int?), int? supportedIops = default(int?), long? supportedMemoryPerVcoreMb = default(long?), System.Collections.Generic.IEnumerable<string> supportedZones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode> supportedHaMode = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature> supportedFeatures = null, string securityProfile = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateEndpointConnectionData PostgreSqlFlexibleServersPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.PostgreSqlFlexibleServersPrivateLinkResourceData PostgreSqlFlexibleServersPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica PostgreSqlFlexibleServersReplica(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? role = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole?), int? capacity = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState? replicationState = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplicationState?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode? promoteMode = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption? promoteOption = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku PostgreSqlFlexibleServersServerSku(string name = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier? tier = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability PostgreSqlFlexibleServerStorageCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, long? supportedIops = default(long?), int? supportedMaximumIops = default(int?), long? storageSizeInMB = default(long?), long? maximumStorageSizeMb = default(long?), int? supportedThroughput = default(int?), int? supportedMaximumThroughput = default(int?), string defaultIopsTier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> supportedIopsTiers = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability PostgreSqlFlexibleServerStorageCapability(string name = null, long? supportedIops = default(long?), long? storageSizeInMB = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> supportedUpgradableTierList = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability PostgreSqlFlexibleServerStorageEditionCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, long? defaultStorageSizeMb = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> supportedStorageCapabilities = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageEditionCapability PostgreSqlFlexibleServerStorageEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability> supportedStorageCapabilities = null, string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability PostgreSqlFlexibleServerStorageTierCapability(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus? capabilityStatus = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexbileServerCapabilityStatus?), string reason = null, string name = null, long? iops = default(long?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability PostgreSqlFlexibleServerStorageTierCapability(string name = null, string tierName = null, long? iops = default(long?), bool? isBaseline = default(bool?), string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails PostgreSqlFlexibleServersValidationDetails(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState?), System.DateTimeOffset? validationStartTimeInUtc = default(System.DateTimeOffset?), System.DateTimeOffset? validationEndTimeInUtc = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem> serverLevelValidationDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DbLevelValidationStatus> dbLevelValidationDetails = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage PostgreSqlFlexibleServersValidationMessage(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState?), string message = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerVCoreCapability PostgreSqlFlexibleServerVCoreCapability(string name = null, long? vCores = default(long?), long? supportedIops = default(long?), long? supportedMemoryPerVCoreInMB = default(long?), string status = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus PostgreSqlMigrationStatus(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState?), string error = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails currentSubStateDetails = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlServerMetadata PostgreSqlServerMetadata(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string version = null, int? storageMb = default(int?), Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersServerSku sku = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage QuotaUsage(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty name = null, long? limit = default(long?), string unit = null, long? currentValue = default(long?), string id = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature SupportedFeature(string name = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus? status = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus?)) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.TuningOptionData TuningOptionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ValidationSummaryItem ValidationSummaryItem(string validationSummaryItemType = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState? state = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationMessage> messages = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.VirtualEndpointData VirtualEndpointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? endpointType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType?), System.Collections.Generic.IEnumerable<string> members = null, System.Collections.Generic.IEnumerable<string> virtualEndpoints = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch VirtualEndpointPatch(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? endpointType = default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType?), System.Collections.Generic.IEnumerable<string> members = null, System.Collections.Generic.IEnumerable<string> virtualEndpoints = null) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel VirtualNetworkSubnetUsageModel(System.Collections.Generic.IEnumerable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage> delegatedSubnetsUsage = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string subscriptionId = null) { throw null; }
    }
    public partial class AuthConfigForPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch>
    {
        public AuthConfigForPatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth? ActiveDirectoryAuth { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth? PasswordAuth { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BackupForPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch>
    {
        public BackupForPatch() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupsLongTermRetentionContent : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBackupContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent>
    {
        public BackupsLongTermRetentionContent(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings backupSettings, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupStoreDetails targetDetails) : base (default(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupSettings)) { }
        public System.Collections.Generic.IList<string> TargetDetailsSasUriList { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupsLongTermRetentionResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>
    {
        internal BackupsLongTermRetentionResponse() { }
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
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupsLongTermRetentionResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType CustomerOnDemand { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType Full { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Cancel : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Cancel(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Capability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability>
    {
        internal Capability() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport? FastProvisioningSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport? GeoBackupSupported { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport? OnlineResizeSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted? Restricted { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport? StorageAutoGrowthSupported { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerFastProvisioningEditionCapability> SupportedFastProvisioningEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature> SupportedFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerEditionCapability> SupportedServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport? ZoneRedundantHaAndGeoBackupSupported { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport? ZoneRedundantHaSupported { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Capability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapturedLog : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog>
    {
        public CapturedLog() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public long? SizeInKb { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CapturedLog>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Cluster : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster>
    {
        public Cluster() { }
        public int? ClusterSize { get { throw null; } set { } }
        public string DefaultDatabaseName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigurationForUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate>
    {
        public ConfigurationForUpdate() { }
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
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ConfigurationForUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreateModeForPatch : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreateModeForPatch(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch Default { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabaseMigrationState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState>
    {
        internal DatabaseMigrationState() { }
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
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState? MigrationState { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataEncryptionType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType AzureKeyVault { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType SystemManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionKeyStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionKeyStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FastProvisioningSupport : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FastProvisioningSupport(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FastProvisioningSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeatureStatus : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeatureStatus(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeographicallyRedundantBackup : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeographicallyRedundantBackup(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GeographicallyRedundantBackupSupport : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GeographicallyRedundantBackupSupport(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackupSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HighAvailabilityForPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch>
    {
        public HighAvailabilityForPatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HighAvailabilityState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HighAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState CreatingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState Healthy { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState RemovingStandby { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState ReplicatingData { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImpactRecord : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord>
    {
        internal ImpactRecord() { }
        public double? AbsoluteValue { get { throw null; } }
        public string DimensionName { get { throw null; } }
        public long? QueryId { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocationRestricted : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocationRestricted(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LocationRestricted right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LogicalReplicationOnSourceServer : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LogicalReplicationOnSourceServer(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MaintenanceWindowForPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch>
    {
        public MaintenanceWindowForPatch() { }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MicrosoftEntraAuth : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MicrosoftEntraAuth(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrateRolesAndPermission : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrateRolesAndPermission(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationDatabaseState : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationDatabaseState(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState Canceling { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState Failed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState InProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState WaitingForCutoverTrigger { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationDatabaseState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationNameAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>
    {
        public MigrationNameAvailability(string name, Azure.Core.ResourceType resourceType) { }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason? Reason { get { throw null; } }
        public Azure.Core.ResourceType ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationNameAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch>
    {
        public MigrationPatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cancel? Cancel { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DbsToCancelMigrationOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToMigrate { get { throw null; } }
        public System.Collections.Generic.IList<string> DbsToTriggerCutoverOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrateRolesAndPermission? MigrateRoles { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationMode? MigrationMode { get { throw null; } set { } }
        public System.DateTimeOffset? MigrationWindowStartTimeInUtc { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer? OverwriteDbsInTarget { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch SecretParameters { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.LogicalReplicationOnSourceServer? SetupLogicalReplicationOnSourceDbIfNeeded { get { throw null; } set { } }
        public string SourceDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceDbServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration? StartDataMigration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string TargetDbServerFullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover? TriggerCutover { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MigrationSecretParametersForPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch>
    {
        public MigrationSecretParametersForPatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AdminCredentialsForPatch AdminCredentials { get { throw null; } set { } }
        public string SourceServerUsername { get { throw null; } set { } }
        public string TargetServerUsername { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSecretParametersForPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MigrationSubstate : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MigrationSubstate(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate CancelingRequestedDBMigrations { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate Completed { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate CompletingMigration { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate MigratingData { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate PerformingPreRequisiteSteps { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate ValidationInProgress { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate WaitingForCutoverTrigger { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate WaitingForDataMigrationScheduling { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate WaitingForDataMigrationWindow { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate WaitingForDBsToMigrateSpecification { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate WaitingForLogicalReplicationSetupRequestOnSourceDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate WaitingForTargetDBOverwriteConfirmation { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MigrationSubstateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails>
    {
        internal MigrationSubstateDetails() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstate? CurrentSubState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DatabaseMigrationState> DbDetails { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationDetails ValidationDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NameAvailabilityModel : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameAvailabilityResponse, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>
    {
        internal NameAvailabilityModel() { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameAvailabilityModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NameProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty>
    {
        internal NameProperty() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectRecommendation : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation>
    {
        public ObjectRecommendation() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload AnalyzedWorkload { get { throw null; } set { } }
        public string CurrentState { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails Details { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ImpactRecord> EstimatedImpact { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails ImplementationDetails { get { throw null; } set { } }
        public System.Collections.Generic.IList<long> ImprovedQueryIds { get { throw null; } }
        public System.DateTimeOffset? InitialRecommendedOn { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.DateTimeOffset? LastRecommendedOn { get { throw null; } set { } }
        public string RecommendationReason { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum? RecommendationType { get { throw null; } set { } }
        public int? TimesRecommended { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectRecommendationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails>
    {
        internal ObjectRecommendationDetails() { }
        public string DatabaseName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IncludedColumns { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> IndexColumns { get { throw null; } }
        public string IndexName { get { throw null; } }
        public string IndexType { get { throw null; } }
        public string Schema { get { throw null; } }
        public string Table { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectRecommendationPropertiesAnalyzedWorkload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload>
    {
        public ObjectRecommendationPropertiesAnalyzedWorkload() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public int? QueryCount { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesAnalyzedWorkload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ObjectRecommendationPropertiesImplementationDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails>
    {
        public ObjectRecommendationPropertiesImplementationDetails() { }
        public string Method { get { throw null; } set { } }
        public string Script { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ObjectRecommendationPropertiesImplementationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineStorageResizeSupport : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineStorageResizeSupport(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OnlineStorageResizeSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OverwriteDatabasesOnTargetServer : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OverwriteDatabasesOnTargetServer(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.OverwriteDatabasesOnTargetServer right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PasswordBasedAuth : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PasswordBasedAuth(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgresMajorVersion : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgresMajorVersion(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Eighteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Eleven { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Fifteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Fourteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Seventeen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Sixteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Thirteen { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion Twelve { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion right) { throw null; }
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
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
    public partial class PostgreSqlFlexibleServerAuthConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>
    {
        public PostgreSqlFlexibleServerAuthConfig() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MicrosoftEntraAuth? ActiveDirectoryAuth { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PasswordBasedAuth? PasswordAuth { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerAuthConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerBackupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerBackupProperties>
    {
        public PostgreSqlFlexibleServerBackupProperties() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.GeographicallyRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType Set { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerConfigurationDataType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption>
    {
        public PostgreSqlFlexibleServerDataEncryption() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.DataEncryptionType? DataEncryptionType { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus? GeoBackupEncryptionKeyStatus { get { throw null; } set { } }
        public System.Uri GeoBackupKeyUri { get { throw null; } set { } }
        public string GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.EncryptionKeyStatus? PrimaryEncryptionKeyStatus { get { throw null; } set { } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public string PrimaryUserAssignedIdentityId { get { throw null; } set { } }
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
        public override bool Equals(object obj) { throw null; }
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
    public partial class PostgreSqlFlexibleServerHighAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailability>
    {
        public PostgreSqlFlexibleServerHighAvailability() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityState? State { get { throw null; } }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode SameZone { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType right) { throw null; }
        public override string ToString() { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PostgreSqlFlexibleServerNameUnavailableReason : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlFlexibleServerNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
    public partial class PostgreSqlFlexibleServerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerPatch>
    {
        public PostgreSqlFlexibleServerPatch() { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AuthConfigForPatch AuthConfig { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.BackupForPatch Backup { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.Cluster Cluster { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.CreateModeForPatch? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.HighAvailabilityForPatch HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MaintenanceWindowForPatch MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersReplica Replica { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch Sku { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage Storage { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgresMajorVersion? Version { get { throw null; } set { } }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature> SupportedFeatures { get { throw null; } }
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
        public string SecurityProfile { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature> SupportedFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerHighAvailabilityMode> SupportedHaMode { get { throw null; } }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption? PromoteOption { get { throw null; } set { } }
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
        public override bool Equals(object obj) { throw null; }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType ApsaraDBRDS { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWS { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWSAurora { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWSEC2 { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AWSRDS { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType AzureVm { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType CrunchyPostgreSQL { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType DigitalOceanDroplets { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType DigitalOceanPostgreSQL { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType EDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType EDBOracleServer { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType EDBPostgreSQL { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCP { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCPAlloyDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCPCloudSQL { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType GCPCompute { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType HerokuPostgreSQL { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType HuaweiCompute { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType HuaweiRDS { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType OnPremises { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType PostgreSQLCosmosDB { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType PostgreSQLFlexibleServer { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType PostgreSQLSingleServer { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType SupabasePostgreSQL { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersSourceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType UltraSSDLRS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersStorageType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Ready { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Restarting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Starting { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.AzureManagedDiskPerformanceTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PostgreSqlFlexibleServerStorageCapability : Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlBaseCapability, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageCapability>
    {
        internal PostgreSqlFlexibleServerStorageCapability() { }
        public string DefaultIopsTier { get { throw null; } }
        public long? MaximumStorageSizeMb { get { throw null; } }
        public string Name { get { throw null; } }
        public long? StorageSizeInMB { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerStorageTierCapability> SupportedIopsTiers { get { throw null; } }
        public int? SupportedMaximumIops { get { throw null; } }
        public int? SupportedMaximumThroughput { get { throw null; } }
        public int? SupportedThroughput { get { throw null; } }
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
        public bool? IsBaseline { get { throw null; } }
        public string Name { get { throw null; } }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServersValidationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlFlexibleServerUserAssignedIdentity
    {
        public PostgreSqlFlexibleServerUserAssignedIdentity(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType identityType) { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerIdentityType IdentityType { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
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
    public readonly partial struct PostgreSqlMigrationListFilter : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PostgreSqlMigrationListFilter(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter Active { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter All { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationListFilter right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PostgreSqlMigrationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>
    {
        internal PostgreSqlMigrationStatus() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.MigrationSubstateDetails CurrentSubStateDetails { get { throw null; } }
        public string Error { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlMigrationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class QuotaUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage>
    {
        internal QuotaUsage() { }
        public long? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.NameProperty Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.QuotaUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReadReplicaPromoteOption : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReadReplicaPromoteOption(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption Forced { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption Planned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ReadReplicaPromoteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationTypeEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationTypeEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum AnalyzeTable { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum CreateIndex { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum DropIndex { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum ReIndex { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecommendationTypeParameterEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecommendationTypeParameterEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum AnalyzeTable { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum CreateIndex { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum DropIndex { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum ReIndex { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.RecommendationTypeParameterEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuForPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch>
    {
        public SkuForPatch() { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SkuForPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StartDataMigration : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StartDataMigration(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StartDataMigration right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrow right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageAutoGrowthSupport : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageAutoGrowthSupport(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.StorageAutoGrowthSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportedFeature : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature>
    {
        internal SupportedFeature() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.FeatureStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.SupportedFeature>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreatProtectionName : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreatProtectionName(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ThreatProtectionName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TriggerCutover : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TriggerCutover(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover False { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TriggerCutover right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TuningOptionParameterEnum : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TuningOptionParameterEnum(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum Index { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum Table { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.TuningOptionParameterEnum right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class VirtualEndpointPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch>
    {
        public VirtualEndpointPatch() { }
        public Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType? EndpointType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Members { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> VirtualEndpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VirtualEndpointType : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VirtualEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkSubnetUsageModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>
    {
        internal VirtualNetworkSubnetUsageModel() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.PostgreSqlFlexibleServerDelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.VirtualNetworkSubnetUsageModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilityAndGeographicallyRedundantBackupSupport right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ZoneRedundantHighAvailabilitySupport : System.IEquatable<Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ZoneRedundantHighAvailabilitySupport(string value) { throw null; }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport Disabled { get { throw null; } }
        public static Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport left, Azure.ResourceManager.PostgreSql.FlexibleServers.Models.ZoneRedundantHighAvailabilitySupport right) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
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
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState left, Azure.ResourceManager.PostgreSql.Models.PostgreSqlVirtualNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
