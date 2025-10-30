namespace Azure.ResourceManager.MySql
{
    public partial class AzureResourceManagerMySqlContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMySqlContext() { }
        public static Azure.ResourceManager.MySql.AzureResourceManagerMySqlContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MySqlAdvisorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>, System.Collections.IEnumerable
    {
        protected MySqlAdvisorCollection() { }
        public virtual Azure.Response<bool> Exists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource> Get(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlAdvisorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlAdvisorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource>> GetAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlAdvisorResource> GetIfExists(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlAdvisorResource>> GetIfExistsAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlAdvisorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlAdvisorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlAdvisorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlAdvisorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlAdvisorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>
    {
        public MySqlAdvisorData() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlAdvisorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlAdvisorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlAdvisorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlAdvisorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlAdvisorResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlAdvisorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation CreateRecommendedActionSession(Azure.WaitUntil waitUntil, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateRecommendedActionSessionAsync(Azure.WaitUntil waitUntil, string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> GetMySqlRecommendationAction(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>> GetMySqlRecommendationActionAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlRecommendationActionCollection GetMySqlRecommendationActions() { throw null; }
        Azure.ResourceManager.MySql.MySqlAdvisorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlAdvisorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlAdvisorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>, System.Collections.IEnumerable
    {
        protected MySqlConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>
    {
        public MySqlConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlConfigurationResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>, System.Collections.IEnumerable
    {
        protected MySqlDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlDatabaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>
    {
        public MySqlDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlDatabaseResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MySqlExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult> CheckMySqlNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>> CheckMySqlNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetLocationBasedPerformanceTiers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetLocationBasedPerformanceTiersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlAdvisorResource GetMySqlAdvisorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlConfigurationResource GetMySqlConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlDatabaseResource GetMySqlDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlFirewallRuleResource GetMySqlFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource GetMySqlPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateLinkResource GetMySqlPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryStatisticResource GetMySqlQueryStatisticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryTextResource GetMySqlQueryTextResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlRecommendationActionResource GetMySqlRecommendationActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerAdministratorResource GetMySqlServerAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> GetMySqlServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerKeyResource GetMySqlServerKeyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerResource GetMySqlServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerCollection GetMySqlServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource GetMySqlServerSecurityAlertPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource GetMySqlVirtualNetworkRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlWaitStatisticResource GetMySqlWaitStatisticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MySqlFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected MySqlFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>
    {
        public MySqlFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFirewallRuleResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MySqlPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>
    {
        public MySqlPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlPrivateLinkResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected MySqlPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>
    {
        public MySqlPrivateLinkResourceData() { }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlQueryStatisticCollection : Azure.ResourceManager.ArmCollection
    {
        protected MySqlQueryStatisticCollection() { }
        public virtual Azure.Response<bool> Exists(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> Get(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> GetAll(Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> GetAllAsync(Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource>> GetAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> GetIfExists(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlQueryStatisticResource>> GetIfExistsAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlQueryStatisticData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>
    {
        public MySqlQueryStatisticData() { }
        public string AggregationFunction { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DatabaseNames { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string MetricDisplayName { get { throw null; } set { } }
        public string MetricName { get { throw null; } set { } }
        public double? MetricValue { get { throw null; } set { } }
        public string MetricValueUnit { get { throw null; } set { } }
        public long? QueryExecutionCount { get { throw null; } set { } }
        public string QueryId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlQueryStatisticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlQueryStatisticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlQueryStatisticResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlQueryStatisticResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlQueryStatisticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string queryStatisticId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlQueryStatisticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlQueryStatisticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryStatisticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlQueryTextCollection : Azure.ResourceManager.ArmCollection
    {
        protected MySqlQueryTextCollection() { }
        public virtual Azure.Response<bool> Exists(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource> Get(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlQueryTextResource> GetAll(System.Collections.Generic.IEnumerable<string> queryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlQueryTextResource> GetAllAsync(System.Collections.Generic.IEnumerable<string> queryIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource>> GetAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlQueryTextResource> GetIfExists(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlQueryTextResource>> GetIfExistsAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlQueryTextData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryTextData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>
    {
        public MySqlQueryTextData() { }
        public string QueryId { get { throw null; } set { } }
        public string QueryText { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlQueryTextData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlQueryTextData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlQueryTextResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryTextData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlQueryTextResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlQueryTextData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string queryId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlQueryTextData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlQueryTextData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlQueryTextData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlRecommendationActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>, System.Collections.IEnumerable
    {
        protected MySqlRecommendationActionCollection() { }
        public virtual Azure.Response<bool> Exists(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> Get(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> GetAll(string sessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> GetAllAsync(string sessionId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>> GetAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> GetIfExists(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>> GetIfExistsAsync(string recommendedActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlRecommendationActionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>
    {
        public MySqlRecommendationActionData() { }
        public int? ActionId { get { throw null; } set { } }
        public string AdvisorName { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Details { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
        public string RecommendationType { get { throw null; } set { } }
        public System.Guid? SessionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlRecommendationActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlRecommendationActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlRecommendationActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlRecommendationActionResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlRecommendationActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string advisorName, string recommendedActionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlRecommendationActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlRecommendationActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlRecommendationActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlRecommendationActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerAdministratorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>
    {
        public MySqlServerAdministratorData() { }
        public Azure.ResourceManager.MySql.Models.MySqlAdministratorType? AdministratorType { get { throw null; } set { } }
        public string LoginAccountName { get { throw null; } set { } }
        public System.Guid? SecureId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerAdministratorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerAdministratorResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlServerAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>, System.Collections.IEnumerable
    {
        protected MySqlServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlServerResource> GetIfExists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlServerResource>> GetIfExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlServerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>
    {
        public MySqlServerData(Azure.Core.AzureLocation location) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string ByokEnforcement { get { throw null; } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } set { } }
        public string FullyQualifiedDomainName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MasterServerId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public int? ReplicaCapacity { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerState? UserVisibleState { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerVersion? Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerKeyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>, System.Collections.IEnumerable
    {
        protected MySqlServerKeyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyName, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerKeyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerKeyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlServerKeyResource> GetIfExists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlServerKeyResource>> GetIfExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlServerKeyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlServerKeyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerKeyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlServerKeyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>
    {
        public MySqlServerKeyData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Kind { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerKeyType? ServerKeyType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerKeyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerKeyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerKeyResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerKeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string keyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlServerKeyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerKeyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerKeyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerKeyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerKeyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.Models.MySqlLogFile> GetLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.MySqlLogFile> GetLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource> GetMySqlAdvisor(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlAdvisorResource>> GetMySqlAdvisorAsync(string advisorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlAdvisorCollection GetMySqlAdvisors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource> GetMySqlConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlConfigurationResource>> GetMySqlConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlConfigurationCollection GetMySqlConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource> GetMySqlDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlDatabaseResource>> GetMySqlDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlDatabaseCollection GetMySqlDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource> GetMySqlFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlFirewallRuleResource>> GetMySqlFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlFirewallRuleCollection GetMySqlFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource> GetMySqlPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource>> GetMySqlPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionCollection GetMySqlPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource> GetMySqlPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlPrivateLinkResource>> GetMySqlPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateLinkResourceCollection GetMySqlPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource> GetMySqlQueryStatistic(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryStatisticResource>> GetMySqlQueryStatisticAsync(string queryStatisticId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlQueryStatisticCollection GetMySqlQueryStatistics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource> GetMySqlQueryText(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlQueryTextResource>> GetMySqlQueryTextAsync(string queryId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlQueryTextCollection GetMySqlQueryTexts() { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerAdministratorResource GetMySqlServerAdministrator() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource> GetMySqlServerKey(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerKeyResource>> GetMySqlServerKeyAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerKeyCollection GetMySqlServerKeys() { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyCollection GetMySqlServerSecurityAlertPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> GetMySqlServerSecurityAlertPolicy(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> GetMySqlServerSecurityAlertPolicyAsync(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> GetMySqlVirtualNetworkRule(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> GetMySqlVirtualNetworkRuleAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleCollection GetMySqlVirtualNetworkRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> GetMySqlWaitStatistic(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource>> GetMySqlWaitStatisticAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlWaitStatisticCollection GetMySqlWaitStatistics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData> GetRecoverableServer(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>> GetRecoverableServerAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetServerBasedPerformanceTiers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetServerBasedPerformanceTiersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult> ResetQueryPerformanceInsightData(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>> ResetQueryPerformanceInsightDataAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.Models.MySqlConfigurations> UpdateConfigurations(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlConfigurations value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.Models.MySqlConfigurations>> UpdateConfigurationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlConfigurations value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Upgrade(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpgradeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlServerSecurityAlertPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>, System.Collections.IEnumerable
    {
        protected MySqlServerSecurityAlertPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> Get(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> GetAsync(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> GetIfExists(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> GetIfExistsAsync(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlServerSecurityAlertPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>
    {
        public MySqlServerSecurityAlertPolicyData() { }
        public System.Collections.Generic.IList<string> DisabledAlerts { get { throw null; } }
        public System.Collections.Generic.IList<string> EmailAddresses { get { throw null; } }
        public int? RetentionDays { get { throw null; } set { } }
        public bool? SendToEmailAccountAdmins { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerSecurityAlertPolicyState? State { get { throw null; } set { } }
        public string StorageAccountAccessKey { get { throw null; } set { } }
        public string StorageEndpoint { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerSecurityAlertPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlServerSecurityAlertPolicyResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName securityAlertPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlVirtualNetworkRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>, System.Collections.IEnumerable
    {
        protected MySqlVirtualNetworkRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string virtualNetworkRuleName, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> Get(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> GetAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> GetIfExists(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> GetIfExistsAsync(string virtualNetworkRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlVirtualNetworkRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>
    {
        public MySqlVirtualNetworkRuleData() { }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState? State { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkSubnetId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlVirtualNetworkRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlVirtualNetworkRuleResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string virtualNetworkRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlWaitStatisticCollection : Azure.ResourceManager.ArmCollection
    {
        protected MySqlWaitStatisticCollection() { }
        public virtual Azure.Response<bool> Exists(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> Get(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> GetAll(Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> GetAllAsync(Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource>> GetAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> GetIfExists(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.MySqlWaitStatisticResource>> GetIfExistsAsync(string waitStatisticsId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlWaitStatisticData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>
    {
        public MySqlWaitStatisticData() { }
        public long? Count { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string EventName { get { throw null; } set { } }
        public string EventTypeName { get { throw null; } set { } }
        public long? QueryId { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public double? TotalTimeInMinutes { get { throw null; } set { } }
        public long? UserId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlWaitStatisticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlWaitStatisticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlWaitStatisticResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlWaitStatisticResource() { }
        public virtual Azure.ResourceManager.MySql.MySqlWaitStatisticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string waitStatisticsId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlWaitStatisticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.MySqlWaitStatisticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.MySqlWaitStatisticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.MySqlWaitStatisticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.FlexibleServers
{
    public partial class AdvancedThreatProtectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>, System.Collections.IEnumerable
    {
        protected AdvancedThreatProtectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> Get(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>> GetAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> GetIfExists(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>> GetIfExistsAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AdvancedThreatProtectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>
    {
        public AdvancedThreatProtectionData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState? State { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdvancedThreatProtectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdvancedThreatProtectionResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FlexibleServersExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult> CheckMySqlFlexibleServerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>> CheckMySqlFlexibleServerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult> CheckMySqlFlexibleServerNameAvailabilityWithoutLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>> CheckMySqlFlexibleServerNameAvailabilityWithoutLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteCheckVirtualNetworkSubnetUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter mySqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteCheckVirtualNetworkSubnetUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter mySqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse> ExecuteGetPrivateDnsZoneSuffix(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>> ExecuteGetPrivateDnsZoneSuffixAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource GetAdvancedThreatProtectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties> GetLocationBasedCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties> GetLocationBasedCapabilitiesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource GetMySqlFlexibleServerAadAdministratorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetMySqlFlexibleServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource GetMySqlFlexibleServerBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource GetMySqlFlexibleServerBackupV2Resource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource GetMySqlFlexibleServerConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource GetMySqlFlexibleServerDatabaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource GetMySqlFlexibleServerFirewallRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource GetMySqlFlexibleServerMaintenanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource GetMySqlFlexibleServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerCollection GetMySqlFlexibleServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityCollection GetMySqlFlexibleServersCapabilities(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> GetMySqlFlexibleServersCapability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>> GetMySqlFlexibleServersCapabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource GetMySqlFlexibleServersCapabilityResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource GetMySqlFlexibleServersPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource GetMySqlFlexibleServersPrivateLinkResourceDataResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult> GetOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>> GetOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerAadAdministratorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerAadAdministratorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> Get(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>> GetAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> GetIfExists(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>> GetIfExistsAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerAadAdministratorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>
    {
        public MySqlFlexibleServerAadAdministratorData() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType? AdministratorType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier IdentityResourceId { get { throw null; } set { } }
        public string Login { get { throw null; } set { } }
        public string Sid { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerAadAdministratorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerAadAdministratorResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerBackupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerBackupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>
    {
        public MySqlFlexibleServerBackupData() { }
        public string BackupType { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerBackupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerBackupResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> Update(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> UpdateAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerBackupV2Collection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerBackupV2Collection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerBackupV2Data : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>
    {
        public MySqlFlexibleServerBackupV2Data() { }
        public string BackupNameV2 { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType? BackupType { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerBackupV2Resource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerBackupV2Resource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string backupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string serverName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> Get(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetIfExists(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetIfExistsAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetReplicas(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetReplicasAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configurationName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> Get(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetAll(string tags = null, string keyword = null, int? page = default(int?), int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetAllAsync(string tags = null, string keyword = null, int? page = default(int?), int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> GetAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetIfExists(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> GetIfExistsAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>
    {
        public MySqlFlexibleServerConfigurationData() { }
        public string AllowedValues { get { throw null; } }
        public string CurrentValue { get { throw null; } set { } }
        public string DataType { get { throw null; } }
        public string DefaultValue { get { throw null; } }
        public string Description { get { throw null; } }
        public string DocumentationLink { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState? IsConfigPendingRestart { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState? IsDynamicConfig { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState? IsReadOnly { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource? Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerConfigurationResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string configurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>
    {
        public MySqlFlexibleServerData(Azure.Core.AzureLocation location) { }
        public string AdministratorLogin { get { throw null; } set { } }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public string AvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode? CreateMode { get { throw null; } set { } }
        public int? DatabasePort { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public string FullVersion { get { throw null; } }
        public string FullyQualifiedDomainName { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties ImportSourceProperties { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy? MaintenancePatchStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork Network { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public int? ReplicaCapacity { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public System.DateTimeOffset? RestorePointInOn { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.DateTimeOffset? RestorePointInTime { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData> ServerPrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceServerResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState? State { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage Storage { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion? Version { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerDatabaseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerDatabaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string databaseName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> Get(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> GetAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> GetIfExists(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> GetIfExistsAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerDatabaseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>
    {
        public MySqlFlexibleServerDatabaseData() { }
        public string Charset { get { throw null; } set { } }
        public string Collation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerDatabaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerDatabaseResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerFirewallRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerFirewallRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string firewallRuleName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> Get(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> GetAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> GetIfExists(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> GetIfExistsAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerFirewallRuleData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>
    {
        public MySqlFlexibleServerFirewallRuleData(System.Net.IPAddress startIPAddress, System.Net.IPAddress endIPAddress) { }
        public System.Net.IPAddress EndIPAddress { get { throw null; } set { } }
        public System.Net.IPAddress StartIPAddress { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerFirewallRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerFirewallRuleResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string firewallRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerMaintenanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServerMaintenanceCollection() { }
        public virtual Azure.Response<bool> Exists(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> Get(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>> GetAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> GetIfExists(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>> GetIfExistsAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServerMaintenanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>
    {
        public MySqlFlexibleServerMaintenanceData() { }
        public System.DateTimeOffset? MaintenanceAvailableScheduleMaxOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceAvailableScheduleMinOn { get { throw null; } }
        public string MaintenanceDescription { get { throw null; } }
        public System.DateTimeOffset? MaintenanceEndOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceExecutionEndOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceExecutionStartOn { get { throw null; } }
        public System.DateTimeOffset? MaintenanceStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState? MaintenanceState { get { throw null; } }
        public string MaintenanceTitle { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType? MaintenanceType { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerMaintenanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerMaintenanceResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string maintenanceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServerResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult> CreateBackupAndExport(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>> CreateBackupAndExportAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> CutoverMigrationServersMigration(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> CutoverMigrationServersMigrationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> DetachVnet(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> DetachVnetAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Failover(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FailoverAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource> GetAdvancedThreatProtection(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource>> GetAdvancedThreatProtectionAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName advancedThreatProtectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionCollection GetAdvancedThreatProtections() { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataCollection GetAllMySqlFlexibleServersPrivateLinkResourceData() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile> GetLogFiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile> GetLogFilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource> GetMySqlFlexibleServerAadAdministrator(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource>> GetMySqlFlexibleServerAadAdministratorAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName administratorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorCollection GetMySqlFlexibleServerAadAdministrators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource> GetMySqlFlexibleServerBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource>> GetMySqlFlexibleServerBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupCollection GetMySqlFlexibleServerBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource> GetMySqlFlexibleServerBackupV2(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource>> GetMySqlFlexibleServerBackupV2Async(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Collection GetMySqlFlexibleServerBackupV2s() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource> GetMySqlFlexibleServerConfiguration(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource>> GetMySqlFlexibleServerConfigurationAsync(string configurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationCollection GetMySqlFlexibleServerConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource> GetMySqlFlexibleServerDatabase(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource>> GetMySqlFlexibleServerDatabaseAsync(string databaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseCollection GetMySqlFlexibleServerDatabases() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource> GetMySqlFlexibleServerFirewallRule(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource>> GetMySqlFlexibleServerFirewallRuleAsync(string firewallRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleCollection GetMySqlFlexibleServerFirewallRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource> GetMySqlFlexibleServerMaintenance(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource>> GetMySqlFlexibleServerMaintenanceAsync(string maintenanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceCollection GetMySqlFlexibleServerMaintenances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> GetMySqlFlexibleServersPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>> GetMySqlFlexibleServersPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionCollection GetMySqlFlexibleServersPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> GetMySqlFlexibleServersPrivateLinkResourceData(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>> GetMySqlFlexibleServersPrivateLinkResourceDataAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResetGtid(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetGtidAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter mySqlFlexibleServerRestartParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter mySqlFlexibleServerRestartParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations> UpdateConfigurations(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate mySqlFlexibleServerConfigurationListForBatchUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>> UpdateConfigurationsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate mySqlFlexibleServerConfigurationListForBatchUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult> ValidateBackup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>> ValidateBackupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation> ValidateEstimateHighAvailability(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation highAvailabilityValidationEstimation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>> ValidateEstimateHighAvailabilityAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation highAvailabilityValidationEstimation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServersCapabilityCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServersCapabilityCollection() { }
        public virtual Azure.Response<bool> Exists(string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> Get(string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>> GetAsync(string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> GetIfExists(string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>> GetIfExistsAsync(string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServersCapabilityData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>
    {
        public MySqlFlexibleServersCapabilityData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty> SupportedFeatures { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedGeoBackupRegions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2> SupportedServerVersions { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServersCapabilityResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServersCapabilityResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation locationName, string capabilitySetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServersPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>
    {
        public MySqlFlexibleServersPrivateEndpointConnectionData() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServersPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateLinkResourceDataCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>, System.Collections.IEnumerable
    {
        protected MySqlFlexibleServersPrivateLinkResourceDataCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateLinkResourceDataData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>
    {
        internal MySqlFlexibleServersPrivateLinkResourceDataData() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateLinkResourceDataResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MySqlFlexibleServersPrivateLinkResourceDataResource() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.FlexibleServers.Mocking
{
    public partial class MockableMySqlFlexibleServersArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMySqlFlexibleServersArmClient() { }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionResource GetAdvancedThreatProtectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorResource GetMySqlFlexibleServerAadAdministratorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupResource GetMySqlFlexibleServerBackupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Resource GetMySqlFlexibleServerBackupV2Resource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationResource GetMySqlFlexibleServerConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseResource GetMySqlFlexibleServerDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleResource GetMySqlFlexibleServerFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceResource GetMySqlFlexibleServerMaintenanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource GetMySqlFlexibleServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource GetMySqlFlexibleServersCapabilityResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionResource GetMySqlFlexibleServersPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataResource GetMySqlFlexibleServersPrivateLinkResourceDataResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMySqlFlexibleServersResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMySqlFlexibleServersResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServer(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource>> GetMySqlFlexibleServerAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerCollection GetMySqlFlexibleServers() { throw null; }
    }
    public partial class MockableMySqlFlexibleServersSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMySqlFlexibleServersSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult> CheckMySqlFlexibleServerNameAvailability(Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>> CheckMySqlFlexibleServerNameAvailabilityAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult> CheckMySqlFlexibleServerNameAvailabilityWithoutLocation(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>> CheckMySqlFlexibleServerNameAvailabilityWithoutLocationAsync(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult> ExecuteCheckVirtualNetworkSubnetUsage(Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter mySqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>> ExecuteCheckVirtualNetworkSubnetUsageAsync(Azure.Core.AzureLocation locationName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter mySqlFlexibleServerVirtualNetworkSubnetUsageParameter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties> GetLocationBasedCapabilities(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties> GetLocationBasedCapabilitiesAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerResource> GetMySqlFlexibleServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityCollection GetMySqlFlexibleServersCapabilities(Azure.Core.AzureLocation locationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource> GetMySqlFlexibleServersCapability(Azure.Core.AzureLocation locationName, string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityResource>> GetMySqlFlexibleServersCapabilityAsync(Azure.Core.AzureLocation locationName, string capabilitySetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult> GetOperationResult(Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>> GetOperationResultAsync(Azure.Core.AzureLocation locationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableMySqlFlexibleServersTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMySqlFlexibleServersTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse> ExecuteGetPrivateDnsZoneSuffix(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>> ExecuteGetPrivateDnsZoneSuffixAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.FlexibleServers.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvancedThreatProtectionName : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvancedThreatProtectionName(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName left, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName left, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdvancedThreatProtectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch>
    {
        public AdvancedThreatProtectionPatch() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvancedThreatProtectionProvisioningState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvancedThreatProtectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdvancedThreatProtectionState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdvancedThreatProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState left, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState left, Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmMySqlFlexibleServersModelFactory
    {
        public static Azure.ResourceManager.MySql.FlexibleServers.AdvancedThreatProtectionData AdvancedThreatProtectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState? state = default(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionState?), Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState? provisioningState = default(Azure.ResourceManager.MySql.FlexibleServers.Models.AdvancedThreatProtectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation HighAvailabilityValidationEstimation(int? estimatedDowntime = default(int?), string scheduledStandbyAvailabilityZone = null, string expectedStandbyAvailabilityZone = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerAadAdministratorData MySqlFlexibleServerAadAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType? administratorType = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType?), string login = null, string sid = null, System.Guid? tenantId = default(System.Guid?), Azure.Core.ResourceIdentifier identityResourceId = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult MySqlFlexibleServerBackupAndExportResult(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportOperationStatus? status, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, double? percentComplete, long? datasourceSizeInBytes, long? dataTransferredInBytes, string backupMetadata, Azure.ResponseError error) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult MySqlFlexibleServerBackupAndExportResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? datasourceSizeInBytes = default(long?), long? dataTransferredInBytes = default(long?), string backupMetadata = null, Azure.ResponseError error = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportOperationStatus? status = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportOperationStatus?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), double? percentComplete = default(double?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupData MySqlFlexibleServerBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string backupType = null, System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string source = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties MySqlFlexibleServerBackupProperties(int? backupRetentionDays = default(int?), int? backupIntervalHours = default(int?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? geoRedundantBackup = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum?), System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings MySqlFlexibleServerBackupSettings(string backupName = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat? backupFormat = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerBackupV2Data MySqlFlexibleServerBackupV2Data(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string backupNameV2 = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType? backupType = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string source = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState? provisioningState = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties MySqlFlexibleServerCapabilityProperties(string zone = null, System.Collections.Generic.IEnumerable<string> supportedHAMode = null, System.Collections.Generic.IEnumerable<string> supportedGeoBackupRegions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability> supportedFlexibleServerEditions = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData MySqlFlexibleServerConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string currentValue = null, string description = null, string documentationLink = null, string defaultValue = null, string dataType = null, string allowedValues = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource? source = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState? isReadOnly = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState? isConfigPendingRestart = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState? isDynamicConfig = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations MySqlFlexibleServerConfigurations(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData> values) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations MySqlFlexibleServerConfigurations(System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData> values = null, System.Uri nextLink = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData MySqlFlexibleServerData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku sku, string administratorLogin, string administratorLoginPassword, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion? version, string availabilityZone, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode? createMode, Azure.Core.ResourceIdentifier sourceServerResourceId, System.DateTimeOffset? restorePointInTime, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole? replicationRole, int? replicaCapacity, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption dataEncryption, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState? state, string fullyQualifiedDomainName, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage storage, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties backup, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability highAvailability, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork network, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection> privateEndpointConnections, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow maintenanceWindow, Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties importSourceProperties) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerData MySqlFlexibleServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string administratorLogin = null, string administratorLoginPassword = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion? version = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion?), string fullVersion = null, string availabilityZone = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode? createMode = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode?), Azure.Core.ResourceIdentifier sourceServerResourceId = null, System.DateTimeOffset? restorePointInOn = default(System.DateTimeOffset?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole? replicationRole = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole?), int? replicaCapacity = default(int?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption dataEncryption = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState? state = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState?), string fullyQualifiedDomainName = null, int? databasePort = default(int?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage storage = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties backup = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability highAvailability = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork network = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData> serverPrivateEndpointConnections = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy? maintenancePatchStrategy = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow maintenanceWindow = null, Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties importSourceProperties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku sku = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerDatabaseData MySqlFlexibleServerDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage MySqlFlexibleServerDelegatedSubnetUsage(string subnetName = null, long? usage = default(long?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability MySqlFlexibleServerEditionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability> supportedServerVersions = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty MySqlFlexibleServerFeatureProperty(string featureName = null, string featureValue = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerFirewallRuleData MySqlFlexibleServerFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability MySqlFlexibleServerHighAvailability(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode? mode = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState? state = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState?), string standbyAvailabilityZone = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile MySqlFlexibleServerLogFile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? sizeInKB = default(long?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string typePropertiesType = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerMaintenanceData MySqlFlexibleServerMaintenanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType? maintenanceType = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState? maintenanceState = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState?), System.DateTimeOffset? maintenanceStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceExecutionStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceExecutionEndOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceAvailableScheduleMinOn = default(System.DateTimeOffset?), System.DateTimeOffset? maintenanceAvailableScheduleMaxOn = default(System.DateTimeOffset?), string maintenanceTitle = null, string maintenanceDescription = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState? provisioningState = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent MySqlFlexibleServerNameAvailabilityContent(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult MySqlFlexibleServerNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string reason = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse MySqlFlexibleServerPrivateDnsZoneSuffixResponse(string privateDnsZoneSuffix = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData MySqlFlexibleServersCapabilityData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IEnumerable<string> supportedGeoBackupRegions, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2> supportedFlexibleServerEditions, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2> supportedServerVersions) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersCapabilityData MySqlFlexibleServersCapabilityData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> supportedGeoBackupRegions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2> supportedFlexibleServerEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2> supportedServerVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty> supportedFeatures = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability MySqlFlexibleServerServerVersionCapability(string name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability> supportedSkus = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability MySqlFlexibleServerSkuCapability(string name = null, long? vCores = default(long?), long? supportedIops = default(long?), long? supportedMemoryPerVCoreInMB = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection MySqlFlexibleServersPrivateEndpointConnection(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IEnumerable<string> groupIds, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState connectionState, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState? provisioningState) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateEndpointConnectionData MySqlFlexibleServersPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServersPrivateLinkResourceDataData MySqlFlexibleServersPrivateLinkResourceDataData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties MySqlFlexibleServersPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage MySqlFlexibleServerStorage(int? storageSizeInGB, int? iops, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? autoGrow, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? logOnDisk, string storageSku, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? autoIoScaling) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage MySqlFlexibleServerStorage(int? storageSizeInGB = default(int?), int? iops = default(int?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? autoGrow = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? logOnDisk = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum?), string storageSku = null, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? autoIoScaling = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum?), Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType? storageRedundancy = default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability MySqlFlexibleServerStorageEditionCapability(string name = null, long? minStorageSize = default(long?), long? maxStorageSize = default(long?), long? minBackupRetentionDays = default(long?), long? maxBackupRetentionDays = default(long?), long? minBackupIntervalHours = default(long?), long? maxBackupIntervalHours = default(long?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult MySqlFlexibleServerValidateBackupResult(int? numberOfContainers = default(int?)) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult MySqlFlexibleServerVirtualNetworkSubnetUsageResult(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string subscriptionId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage> delegatedSubnetsUsage = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult OperationStatusExtendedResult(Azure.Core.ResourceIdentifier id, Azure.Core.ResourceIdentifier resourceId, string name, string status, float? percentComplete, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult> operations, Azure.ResponseError error, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> properties) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult OperationStatusResult(Azure.Core.ResourceIdentifier id, Azure.Core.ResourceIdentifier resourceId, string name, string status, float? percentComplete, System.DateTimeOffset? startOn, System.DateTimeOffset? endOn, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult> operations, Azure.ResponseError error) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2 ServerEditionCapabilityV2(string name = null, string defaultSku = null, int? defaultStorageSize = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability> supportedStorageEditions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2> supportedSkus = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2 ServerVersionCapabilityV2(string name = null) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2 SkuCapabilityV2(string name = null, long? vCores = default(long?), long? supportedIops = default(long?), long? supportedMemoryPerVCoreMB = default(long?), System.Collections.Generic.IEnumerable<string> supportedZones = null, System.Collections.Generic.IEnumerable<string> supportedHAMode = null) { throw null; }
    }
    public partial class HighAvailabilityValidationEstimation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>
    {
        public HighAvailabilityValidationEstimation() { }
        public int? EstimatedDowntime { get { throw null; } }
        public string ExpectedStandbyAvailabilityZone { get { throw null; } set { } }
        public string ScheduledStandbyAvailabilityZone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.HighAvailabilityValidationEstimation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImportSourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties>
    {
        public ImportSourceProperties() { }
        public string DataDirPath { get { throw null; } set { } }
        public string SasToken { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType? StorageType { get { throw null; } set { } }
        public System.Uri StorageUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImportSourceStorageType : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImportSourceStorageType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType AzureBlob { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType left, Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType left, Azure.ResourceManager.MySql.FlexibleServers.Models.ImportSourceStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerAdministratorName : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerAdministratorName(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerAdministratorType : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerAdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerAdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerBackupAndExportContent : Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent>
    {
        public MySqlFlexibleServerBackupAndExportContent(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings backupSettings, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails targetDetails) : base (default(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings)) { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails TargetDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MySqlFlexibleServerBackupAndExportOperationStatus
    {
        Pending = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
        CancelInProgress = 4,
        Canceled = 5,
    }
    public partial class MySqlFlexibleServerBackupAndExportResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>
    {
        public MySqlFlexibleServerBackupAndExportResult() { }
        public string BackupMetadata { get { throw null; } set { } }
        public long? DatasourceSizeInBytes { get { throw null; } set { } }
        public long? DataTransferredInBytes { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } set { } }
        public double? PercentComplete { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportOperationStatus? Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupAndExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerBackupContentBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase>
    {
        public MySqlFlexibleServerBackupContentBase(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings backupSettings) { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings BackupSettings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupContentBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerBackupFormat : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerBackupFormat(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat CollatedFormat { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat Raw { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerBackupProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties>
    {
        public MySqlFlexibleServerBackupProperties() { }
        public int? BackupIntervalHours { get { throw null; } set { } }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public System.DateTimeOffset? EarliestRestoreOn { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? GeoRedundantBackup { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerBackupProvisioningState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerBackupProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerBackupSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings>
    {
        public MySqlFlexibleServerBackupSettings(string backupName) { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupFormat? BackupFormat { get { throw null; } set { } }
        public string BackupName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MySqlFlexibleServerBackupStoreDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails>
    {
        protected MySqlFlexibleServerBackupStoreDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerBackupType : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerBackupType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType Full { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerBatchOfMaintenance : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerBatchOfMaintenance(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance Batch1 { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance Batch2 { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerCapabilityProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties>
    {
        internal MySqlFlexibleServerCapabilityProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability> SupportedFlexibleServerEditions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedGeoBackupRegions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAMode { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCapabilityProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigDynamicState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigDynamicState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigDynamicState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigPendingRestartState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigPendingRestartState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigPendingRestartState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigReadOnlyState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigReadOnlyState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigReadOnlyState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationForBatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate>
    {
        public MySqlFlexibleServerConfigurationForBatchUpdate() { }
        public string Name { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurationListForBatchUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate>
    {
        public MySqlFlexibleServerConfigurationListForBatchUpdate() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault? ResetAllToDefault { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationForBatchUpdate> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationListForBatchUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigurationResetAllToDefault : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigurationResetAllToDefault(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault False { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationResetAllToDefault right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>
    {
        internal MySqlFlexibleServerConfigurations() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.MySqlFlexibleServerConfigurationData> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerConfigurationSource : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerConfigurationSource(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource SystemDefault { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource UserOverride { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerConfigurationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerCreateMode : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode GeoRestore { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode PointInTimeRestore { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode Replica { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerDataEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption>
    {
        public MySqlFlexibleServerDataEncryption() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryptionType? EncryptionType { get { throw null; } set { } }
        public System.Uri GeoBackupKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier GeoBackupUserAssignedIdentityId { get { throw null; } set { } }
        public System.Uri PrimaryKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrimaryUserAssignedIdentityId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MySqlFlexibleServerDataEncryptionType
    {
        AzureKeyVault = 0,
        SystemManaged = 1,
    }
    public partial class MySqlFlexibleServerDelegatedSubnetUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage>
    {
        internal MySqlFlexibleServerDelegatedSubnetUsage() { }
        public string SubnetName { get { throw null; } }
        public long? Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerDetachVnetContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent>
    {
        public MySqlFlexibleServerDetachVnetContent() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDetachVnetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerEditionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability>
    {
        internal MySqlFlexibleServerEditionCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability> SupportedServerVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerEnableStatusEnum : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerEnableStatusEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerFeatureProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty>
    {
        internal MySqlFlexibleServerFeatureProperty() { }
        public string FeatureName { get { throw null; } }
        public string FeatureValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFeatureProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerFullBackupStoreDetails : Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupStoreDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails>
    {
        public MySqlFlexibleServerFullBackupStoreDetails(System.Collections.Generic.IEnumerable<string> sasUriList) { }
        public System.Collections.Generic.IList<string> SasUriList { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerFullBackupStoreDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerGtidSetContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent>
    {
        public MySqlFlexibleServerGtidSetContent() { }
        public string GtidSet { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerGtidSetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerHighAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability>
    {
        public MySqlFlexibleServerHighAvailability() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode? Mode { get { throw null; } set { } }
        public string StandbyAvailabilityZone { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerHighAvailabilityMode : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerHighAvailabilityMode(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode SameZone { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerHighAvailabilityState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerHighAvailabilityState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState CreatingStandby { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState FailingOver { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState Healthy { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState RemovingStandby { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailabilityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerLogFile : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile>
    {
        public MySqlFlexibleServerLogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public long? SizeInKB { get { throw null; } set { } }
        public string TypePropertiesType { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerLogFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerMaintenancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch>
    {
        public MySqlFlexibleServerMaintenancePatch() { }
        public System.DateTimeOffset? MaintenanceStartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerMaintenanceProvisioningState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerMaintenanceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerMaintenanceState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerMaintenanceState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState Canceled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState Completed { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState InPreparation { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState Processing { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState ReScheduled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerMaintenanceType : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerMaintenanceType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType HotFixes { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType MinorVersionUpgrade { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType RoutineMaintenance { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType SecurityPatches { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerMaintenanceWindow : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow>
    {
        public MySqlFlexibleServerMaintenanceWindow() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBatchOfMaintenance? BatchOfMaintenance { get { throw null; } set { } }
        public string CustomWindow { get { throw null; } set { } }
        public int? DayOfWeek { get { throw null; } set { } }
        public int? StartHour { get { throw null; } set { } }
        public int? StartMinute { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent>
    {
        public MySqlFlexibleServerNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>
    {
        internal MySqlFlexibleServerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerNetwork : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork>
    {
        public MySqlFlexibleServerNetwork() { }
        public Azure.Core.ResourceIdentifier DelegatedSubnetResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateDnsZoneResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch>
    {
        public MySqlFlexibleServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerBackupProperties Backup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDataEncryption DataEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerHighAvailability HighAvailability { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy? MaintenancePatchStrategy { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerMaintenanceWindow MaintenanceWindow { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerNetwork Network { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole? ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage Storage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerPatchStrategy : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerPatchStrategy(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy Regular { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy VirtualCanary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPatchStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerPrivateDnsZoneSuffixResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>
    {
        internal MySqlFlexibleServerPrivateDnsZoneSuffixResponse() { }
        public string PrivateDnsZoneSuffix { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerPrivateDnsZoneSuffixResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerReplicationRole : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerReplicationRole(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole None { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole Replica { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerReplicationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerRestartParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter>
    {
        public MySqlFlexibleServerRestartParameter() { }
        public int? MaxFailoverSeconds { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? RestartWithFailover { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerRestartParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerServerVersionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability>
    {
        internal MySqlFlexibleServerServerVersionCapability() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability> SupportedSkus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerServerVersionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku>
    {
        public MySqlFlexibleServerSku(string name, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier tier) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability>
    {
        internal MySqlFlexibleServerSkuCapability() { }
        public string Name { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVCoreInMB { get { throw null; } }
        public long? VCores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerSkuTier : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier Burstable { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection>
    {
        public MySqlFlexibleServersPrivateEndpointConnection() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServersPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServersPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServersPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServersPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties>
    {
        internal MySqlFlexibleServersPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServersPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState>
    {
        public MySqlFlexibleServersPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServersPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerState : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Starting { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Stopped { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Stopping { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage>
    {
        public MySqlFlexibleServerStorage() { }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? AutoGrow { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? AutoIoScaling { get { throw null; } set { } }
        public int? Iops { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerEnableStatusEnum? LogOnDisk { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType? StorageRedundancy { get { throw null; } set { } }
        public int? StorageSizeInGB { get { throw null; } set { } }
        public string StorageSku { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerStorageEditionCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability>
    {
        internal MySqlFlexibleServerStorageEditionCapability() { }
        public long? MaxBackupIntervalHours { get { throw null; } }
        public long? MaxBackupRetentionDays { get { throw null; } }
        public long? MaxStorageSize { get { throw null; } }
        public long? MinBackupIntervalHours { get { throw null; } }
        public long? MinBackupRetentionDays { get { throw null; } }
        public long? MinStorageSize { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerStorageRedundancyType : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerStorageRedundancyType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType LocalRedundancy { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType ZoneRedundancy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageRedundancyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerValidateBackupResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>
    {
        internal MySqlFlexibleServerValidateBackupResult() { }
        public int? NumberOfContainers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerValidateBackupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlFlexibleServerVersion : System.IEquatable<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlFlexibleServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion Ver5_7 { get { throw null; } }
        public static Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion Ver8_0_21 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion left, Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlFlexibleServerVirtualNetworkSubnetUsageParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter>
    {
        public MySqlFlexibleServerVirtualNetworkSubnetUsageParameter() { }
        public Azure.Core.ResourceIdentifier VirtualNetworkResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlFlexibleServerVirtualNetworkSubnetUsageResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>
    {
        internal MySqlFlexibleServerVirtualNetworkSubnetUsageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerDelegatedSubnetUsage> DelegatedSubnetsUsage { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerVirtualNetworkSubnetUsageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class OperationStatusExtendedResult : Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>
    {
        internal OperationStatusExtendedResult() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusExtendedResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class OperationStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult>
    {
        internal OperationStatusResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult> Operations { get { throw null; } }
        public float? PercentComplete { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.OperationStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerEditionCapabilityV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2>
    {
        internal ServerEditionCapabilityV2() { }
        public string DefaultSku { get { throw null; } }
        public int? DefaultStorageSize { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2> SupportedSkus { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.FlexibleServers.Models.MySqlFlexibleServerStorageEditionCapability> SupportedStorageEditions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerEditionCapabilityV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServerVersionCapabilityV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2>
    {
        internal ServerVersionCapabilityV2() { }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.ServerVersionCapabilityV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuCapabilityV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2>
    {
        internal SkuCapabilityV2() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedHAMode { get { throw null; } }
        public long? SupportedIops { get { throw null; } }
        public long? SupportedMemoryPerVCoreMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> SupportedZones { get { throw null; } }
        public long? VCores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.FlexibleServers.Models.SkuCapabilityV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.Mocking
{
    public partial class MockableMySqlArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMySqlArmClient() { }
        public virtual Azure.ResourceManager.MySql.MySqlAdvisorResource GetMySqlAdvisorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlConfigurationResource GetMySqlConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlDatabaseResource GetMySqlDatabaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlFirewallRuleResource GetMySqlFirewallRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionResource GetMySqlPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlPrivateLinkResource GetMySqlPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlQueryStatisticResource GetMySqlQueryStatisticResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlQueryTextResource GetMySqlQueryTextResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlRecommendationActionResource GetMySqlRecommendationActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerAdministratorResource GetMySqlServerAdministratorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerKeyResource GetMySqlServerKeyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerResource GetMySqlServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyResource GetMySqlServerSecurityAlertPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleResource GetMySqlVirtualNetworkRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlWaitStatisticResource GetMySqlWaitStatisticResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMySqlResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMySqlResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServer(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.MySqlServerResource>> GetMySqlServerAsync(string serverName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MySql.MySqlServerCollection GetMySqlServers() { throw null; }
    }
    public partial class MockableMySqlSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMySqlSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult> CheckMySqlNameAvailability(Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>> CheckMySqlNameAvailabilityAsync(Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetLocationBasedPerformanceTiers(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier> GetLocationBasedPerformanceTiersAsync(Azure.Core.AzureLocation locationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MySql.MySqlServerResource> GetMySqlServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MySql.Models
{
    public static partial class ArmMySqlModelFactory
    {
        public static Azure.ResourceManager.MySql.MySqlAdvisorData MySqlAdvisorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData properties = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlConfigurationData MySqlConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string value = null, string description = null, string defaultValue = null, string dataType = null, string allowedValues = null, string source = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlDatabaseData MySqlDatabaseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string charset = null, string collation = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlFirewallRuleData MySqlFirewallRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Net.IPAddress startIPAddress = null, System.Net.IPAddress endIPAddress = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlLogFile MySqlLogFile(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, long? sizeInKB = default(long?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string logFileType = null, System.Uri uri = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent MySqlNameAvailabilityContent(string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?)) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult MySqlNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), string reason = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPerformanceTier MySqlPerformanceTier(string id = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minLargeStorageInMB = default(int?), int? maxLargeStorageInMB = default(int?), int? minStorageInMB = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives> serviceLevelObjectives = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives MySqlPerformanceTierServiceLevelObjectives(string id = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, int? maxBackupRetentionDays = default(int?), int? minBackupRetentionDays = default(int?), int? maxStorageInMB = default(int?), int? minStorageInMB = default(int?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateEndpointConnectionData MySqlPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty connectionState = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlPrivateLinkResourceData MySqlPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties MySqlPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty MySqlPrivateLinkServiceConnectionStateProperty(string status = null, string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult MySqlQueryPerformanceInsightResetDataResult(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState? status = default(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState?), string message = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryStatisticData MySqlQueryStatisticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string queryId = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string aggregationFunction = null, System.Collections.Generic.IEnumerable<string> databaseNames = null, long? queryExecutionCount = default(long?), string metricName = null, string metricDisplayName = null, double? metricValue = default(double?), string metricValueUnit = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlQueryTextData MySqlQueryTextData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string queryId = null, string queryText = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlRecommendationActionData MySqlRecommendationActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string advisorName = null, System.Guid? sessionId = default(System.Guid?), int? actionId = default(int?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), string reason = null, string recommendationType = null, System.Collections.Generic.IDictionary<string, string> details = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData MySqlRecoverableServerResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? lastAvailableBackupOn = default(System.DateTimeOffset?), string serviceLevelObjective = null, string edition = null, int? vCores = default(int?), string hardwareGeneration = null, string version = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerAdministratorData MySqlServerAdministratorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.Models.MySqlAdministratorType? administratorType = default(Azure.ResourceManager.MySql.Models.MySqlAdministratorType?), string loginAccountName = null, System.Guid? secureId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent MySqlServerCreateOrUpdateContent(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.MySql.Models.MySqlSku sku = null, Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate properties = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerData MySqlServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.MySql.Models.MySqlSku sku = null, string administratorLogin = null, Azure.ResourceManager.MySql.Models.MySqlServerVersion? version = default(Azure.ResourceManager.MySql.Models.MySqlServerVersion?), Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum?), Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum?), string byokEnforcement = null, Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption?), Azure.ResourceManager.MySql.Models.MySqlServerState? userVisibleState = default(Azure.ResourceManager.MySql.Models.MySqlServerState?), string fullyQualifiedDomainName = null, System.DateTimeOffset? earliestRestoreOn = default(System.DateTimeOffset?), Azure.ResourceManager.MySql.Models.MySqlStorageProfile storageProfile = null, string replicationRole = null, Azure.Core.ResourceIdentifier masterServerId = null, int? replicaCapacity = default(int?), Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerKeyData MySqlServerKeyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string kind = null, Azure.ResourceManager.MySql.Models.MySqlServerKeyType? serverKeyType = default(Azure.ResourceManager.MySql.Models.MySqlServerKeyType?), System.Uri uri = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection MySqlServerPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties MySqlServerPrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty privateLinkServiceConnectionState = null, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState? provisioningState = default(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty MySqlServerPrivateLinkServiceConnectionStateProperty(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus status = default(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus), string description = null, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction? actionsRequired = default(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction?)) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate MySqlServerPropertiesForDefaultCreate(Azure.ResourceManager.MySql.Models.MySqlServerVersion? version = default(Azure.ResourceManager.MySql.Models.MySqlServerVersion?), Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum?), Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum?), Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption?), Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum?), Azure.ResourceManager.MySql.Models.MySqlStorageProfile storageProfile = null, string administratorLogin = null, string administratorLoginPassword = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore MySqlServerPropertiesForGeoRestore(Azure.ResourceManager.MySql.Models.MySqlServerVersion? version = default(Azure.ResourceManager.MySql.Models.MySqlServerVersion?), Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum?), Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum?), Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption?), Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum?), Azure.ResourceManager.MySql.Models.MySqlStorageProfile storageProfile = null, Azure.Core.ResourceIdentifier sourceServerId = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica MySqlServerPropertiesForReplica(Azure.ResourceManager.MySql.Models.MySqlServerVersion? version = default(Azure.ResourceManager.MySql.Models.MySqlServerVersion?), Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum?), Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum?), Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption?), Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum?), Azure.ResourceManager.MySql.Models.MySqlStorageProfile storageProfile = null, Azure.Core.ResourceIdentifier sourceServerId = null) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore MySqlServerPropertiesForRestore(Azure.ResourceManager.MySql.Models.MySqlServerVersion? version = default(Azure.ResourceManager.MySql.Models.MySqlServerVersion?), Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? sslEnforcement = default(Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum?), Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? minimalTlsVersion = default(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum?), Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? infrastructureEncryption = default(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption?), Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? publicNetworkAccess = default(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum?), Azure.ResourceManager.MySql.Models.MySqlStorageProfile storageProfile = null, Azure.Core.ResourceIdentifier sourceServerId = null, System.DateTimeOffset restorePointInTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlServerSecurityAlertPolicyData MySqlServerSecurityAlertPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.MySql.Models.MySqlServerSecurityAlertPolicyState? state = default(Azure.ResourceManager.MySql.Models.MySqlServerSecurityAlertPolicyState?), System.Collections.Generic.IEnumerable<string> disabledAlerts = null, System.Collections.Generic.IEnumerable<string> emailAddresses = null, bool? sendToEmailAccountAdmins = default(bool?), string storageEndpoint = null, string storageAccountAccessKey = null, int? retentionDays = default(int?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlVirtualNetworkRuleData MySqlVirtualNetworkRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier virtualNetworkSubnetId = null, bool? ignoreMissingVnetServiceEndpoint = default(bool?), Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState? state = default(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState?)) { throw null; }
        public static Azure.ResourceManager.MySql.MySqlWaitStatisticData MySqlWaitStatisticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string eventName = null, string eventTypeName = null, long? queryId = default(long?), string databaseName = null, long? userId = default(long?), long? count = default(long?), double? totalTimeInMinutes = default(double?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlAdministratorType : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlAdministratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlAdministratorType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlAdministratorType ActiveDirectory { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlAdministratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlAdministratorType left, Azure.ResourceManager.MySql.Models.MySqlAdministratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlAdministratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlAdministratorType left, Azure.ResourceManager.MySql.Models.MySqlAdministratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlConfigurations>
    {
        public MySqlConfigurations() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.MySql.MySqlConfigurationData> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlGeoRedundantBackup : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlGeoRedundantBackup(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup left, Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup left, Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlInfrastructureEncryption : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlInfrastructureEncryption(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption left, Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption left, Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlLogFile : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlLogFile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlLogFile>
    {
        public MySqlLogFile() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string LogFileType { get { throw null; } set { } }
        public long? SizeInKB { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlLogFile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlLogFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlLogFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlLogFile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlLogFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlLogFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlLogFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlMinimalTlsVersionEnum : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlMinimalTlsVersionEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum Tls1_0 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum Tls1_1 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum Tls1_2 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum TLSEnforcementDisabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum left, Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum left, Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent>
    {
        public MySqlNameAvailabilityContent(string name) { }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>
    {
        internal MySqlNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlPerformanceTier : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier>
    {
        internal MySqlPerformanceTier() { }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxLargeStorageInMB { get { throw null; } }
        public int? MaxStorageInMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinLargeStorageInMB { get { throw null; } }
        public int? MinStorageInMB { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives> ServiceLevelObjectives { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPerformanceTier System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPerformanceTier System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTier>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlPerformanceTierServiceLevelObjectives : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives>
    {
        internal MySqlPerformanceTierServiceLevelObjectives() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public string Id { get { throw null; } }
        public int? MaxBackupRetentionDays { get { throw null; } }
        public int? MaxStorageInMB { get { throw null; } }
        public int? MinBackupRetentionDays { get { throw null; } }
        public int? MinStorageInMB { get { throw null; } }
        public int? VCores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPerformanceTierServiceLevelObjectives>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlPrivateEndpointConnectionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch>
    {
        public MySqlPrivateEndpointConnectionPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointConnectionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPrivateEndpointProvisioningState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPrivateEndpointProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Approving { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState Rejecting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState left, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState left, Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties>
    {
        internal MySqlPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlPrivateLinkServiceConnectionStateProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty>
    {
        public MySqlPrivateLinkServiceConnectionStateProperty(string status, string description) { }
        public string ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPrivateLinkServiceConnectionStateRequiredAction : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPrivateLinkServiceConnectionStateRequiredAction(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPrivateLinkServiceConnectionStateStatus : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPrivateLinkServiceConnectionStateStatus(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus left, Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlPublicNetworkAccessEnum : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlPublicNetworkAccessEnum(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum left, Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum left, Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlQueryPerformanceInsightResetDataResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>
    {
        internal MySqlQueryPerformanceInsightResetDataResult() { }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlQueryPerformanceInsightResetDataResultState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlQueryPerformanceInsightResetDataResultState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState Failed { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState left, Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState left, Azure.ResourceManager.MySql.Models.MySqlQueryPerformanceInsightResetDataResultState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlRecoverableServerResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>
    {
        public MySqlRecoverableServerResourceData() { }
        public string Edition { get { throw null; } }
        public string HardwareGeneration { get { throw null; } }
        public System.DateTimeOffset? LastAvailableBackupOn { get { throw null; } }
        public string ServiceLevelObjective { get { throw null; } }
        public int? VCores { get { throw null; } }
        public string Version { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlRecoverableServerResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlSecurityAlertPolicyName : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlSecurityAlertPolicyName(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName Default { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName left, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName left, Azure.ResourceManager.MySql.Models.MySqlSecurityAlertPolicyName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlServerCreateOrUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent>
    {
        public MySqlServerCreateOrUpdateContent(Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate properties, Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate Properties { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlServerKeyType : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlServerKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlServerKeyType(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerKeyType AzureKeyVault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlServerKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlServerKeyType left, Azure.ResourceManager.MySql.Models.MySqlServerKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlServerKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlServerKeyType left, Azure.ResourceManager.MySql.Models.MySqlServerKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlServerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPatch>
    {
        public MySqlServerPatch() { }
        public string AdministratorLoginPassword { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public string ReplicationRole { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageProfile StorageProfile { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerVersion? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerPrivateEndpointConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection>
    {
        internal MySqlServerPrivateEndpointConnection() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties>
    {
        internal MySqlServerPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateEndpointProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerPrivateLinkServiceConnectionStateProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty>
    {
        internal MySqlServerPrivateLinkServiceConnectionStateProperty() { }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateRequiredAction? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.MySql.Models.MySqlPrivateLinkServiceConnectionStateStatus Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPrivateLinkServiceConnectionStateProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MySqlServerPropertiesForCreate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate>
    {
        protected MySqlServerPropertiesForCreate() { }
        public Azure.ResourceManager.MySql.Models.MySqlInfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlMinimalTlsVersionEnum? MinimalTlsVersion { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlPublicNetworkAccessEnum? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSslEnforcementEnum? SslEnforcement { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageProfile StorageProfile { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlServerVersion? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerPropertiesForDefaultCreate : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate>
    {
        public MySqlServerPropertiesForDefaultCreate(string administratorLogin, string administratorLoginPassword) { }
        public string AdministratorLogin { get { throw null; } }
        public string AdministratorLoginPassword { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForDefaultCreate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerPropertiesForGeoRestore : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore>
    {
        public MySqlServerPropertiesForGeoRestore(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForGeoRestore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerPropertiesForReplica : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica>
    {
        public MySqlServerPropertiesForReplica(Azure.Core.ResourceIdentifier sourceServerId) { }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForReplica>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlServerPropertiesForRestore : Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForCreate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore>
    {
        public MySqlServerPropertiesForRestore(Azure.Core.ResourceIdentifier sourceServerId, System.DateTimeOffset restorePointInTime) { }
        public System.DateTimeOffset RestorePointInTime { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceServerId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerPropertiesForRestore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MySqlServerSecurityAlertPolicyState
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlServerState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlServerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlServerState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Dropping { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Inaccessible { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerState Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlServerState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlServerState left, Azure.ResourceManager.MySql.Models.MySqlServerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlServerState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlServerState left, Azure.ResourceManager.MySql.Models.MySqlServerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlServerUpgradeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent>
    {
        public MySqlServerUpgradeContent() { }
        public string TargetServerVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlServerUpgradeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlServerVersion : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlServerVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlServerVersion(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlServerVersion Ver5_6 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerVersion Ver5_7 { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlServerVersion Ver8_0 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlServerVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlServerVersion left, Azure.ResourceManager.MySql.Models.MySqlServerVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlServerVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlServerVersion left, Azure.ResourceManager.MySql.Models.MySqlServerVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlSku>
    {
        public MySqlSku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlSkuTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlSkuTier : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlSkuTier Basic { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlSkuTier GeneralPurpose { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlSkuTier MemoryOptimized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlSkuTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlSkuTier left, Azure.ResourceManager.MySql.Models.MySqlSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlSkuTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlSkuTier left, Azure.ResourceManager.MySql.Models.MySqlSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum MySqlSslEnforcementEnum
    {
        Enabled = 0,
        Disabled = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlStorageAutogrow : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlStorageAutogrow(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow Disabled { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow left, Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow left, Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlStorageProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlStorageProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlStorageProfile>
    {
        public MySqlStorageProfile() { }
        public int? BackupRetentionDays { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlGeoRedundantBackup? GeoRedundantBackup { get { throw null; } set { } }
        public Azure.ResourceManager.MySql.Models.MySqlStorageAutogrow? StorageAutogrow { get { throw null; } set { } }
        public int? StorageInMB { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlStorageProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlStorageProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlStorageProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlStorageProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlStorageProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlStorageProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlStorageProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MySqlTopQueryStatisticsInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput>
    {
        public MySqlTopQueryStatisticsInput(int numberOfTopQueries, string aggregationFunction, string observedMetric, System.DateTimeOffset observationStartOn, System.DateTimeOffset observationEndOn, string aggregationWindow) { }
        public string AggregationFunction { get { throw null; } }
        public string AggregationWindow { get { throw null; } }
        public int NumberOfTopQueries { get { throw null; } }
        public System.DateTimeOffset ObservationEndOn { get { throw null; } }
        public System.DateTimeOffset ObservationStartOn { get { throw null; } }
        public string ObservedMetric { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlTopQueryStatisticsInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MySqlVirtualNetworkRuleState : System.IEquatable<Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MySqlVirtualNetworkRuleState(string value) { throw null; }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Deleting { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Initializing { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState InProgress { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Ready { get { throw null; } }
        public static Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState left, Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState right) { throw null; }
        public static implicit operator Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState left, Azure.ResourceManager.MySql.Models.MySqlVirtualNetworkRuleState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MySqlWaitStatisticsInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput>
    {
        public MySqlWaitStatisticsInput(System.DateTimeOffset observationStartOn, System.DateTimeOffset observationEndOn, string aggregationWindow) { }
        public string AggregationWindow { get { throw null; } }
        public System.DateTimeOffset ObservationEndOn { get { throw null; } }
        public System.DateTimeOffset ObservationStartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MySql.Models.MySqlWaitStatisticsInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
