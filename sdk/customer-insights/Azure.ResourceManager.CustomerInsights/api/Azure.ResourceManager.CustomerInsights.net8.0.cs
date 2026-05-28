namespace Azure.ResourceManager.CustomerInsights
{
    public partial class AuthorizationPolicyResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>, System.Collections.IEnumerable
    {
        protected AuthorizationPolicyResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string authorizationPolicyName, Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string authorizationPolicyName, Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> Get(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>> GetAsync(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> GetIfExists(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>> GetIfExistsAsync(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AuthorizationPolicyResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>
    {
        public AuthorizationPolicyResourceFormatData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.PermissionType> Permissions { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public string PrimaryKey { get { throw null; } set { } }
        public string SecondaryKey { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationPolicyResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AuthorizationPolicyResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string authorizationPolicyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy> RegeneratePrimaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>> RegeneratePrimaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy> RegenerateSecondaryKey(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>> RegenerateSecondaryKeyAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerCustomerInsightsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCustomerInsightsContext() { }
        public static Azure.ResourceManager.CustomerInsights.AzureResourceManagerCustomerInsightsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConnectorMappingResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>, System.Collections.IEnumerable
    {
        protected ConnectorMappingResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string mappingName, Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string mappingName, Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> Get(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>> GetAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> GetIfExists(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>> GetIfExistsAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectorMappingResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>
    {
        public ConnectorMappingResourceFormatData() { }
        public string ConnectorMappingName { get { throw null; } }
        public string ConnectorName { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorType? ConnectorType { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string DataFormatId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.EntityType? EntityType { get { throw null; } set { } }
        public string EntityTypeName { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties MappingProperties { get { throw null; } set { } }
        public System.DateTimeOffset? NextRunOn { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingState? State { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorMappingResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectorMappingResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string connectorName, string mappingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConnectorResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>, System.Collections.IEnumerable
    {
        protected ConnectorResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConnectorResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>
    {
        public ConnectorResourceFormatData() { }
        public int? ConnectorId { get { throw null; } }
        public string ConnectorName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ConnectorProperties { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorType? ConnectorType { get { throw null; } set { } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? IsInternal { get { throw null; } set { } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorState? State { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConnectorResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource> GetConnectorMappingResourceFormat(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource>> GetConnectorMappingResourceFormatAsync(string mappingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatCollection GetConnectorMappingResourceFormats() { throw null; }
        Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class CustomerInsightsExtensions
    {
        public static Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource GetAuthorizationPolicyResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource GetConnectorMappingResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource GetConnectorResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> GetHub(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> GetHubAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.HubResource GetHubResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.HubCollection GetHubs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.CustomerInsights.HubResource> GetHubs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.HubResource> GetHubsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource GetInteractionResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource GetKpiResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource GetLinkResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource GetPredictionResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource GetProfileResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource GetRelationshipLinkResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource GetRelationshipResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource GetRoleAssignmentResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource GetViewResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource GetWidgetTypeResourceFormatResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HubCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.HubResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.HubResource>, System.Collections.IEnumerable
    {
        protected HubCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.HubResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string hubName, Azure.ResourceManager.CustomerInsights.HubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.HubResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string hubName, Azure.ResourceManager.CustomerInsights.HubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> Get(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.HubResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.HubResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> GetAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.HubResource> GetIfExists(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.HubResource>> GetIfExistsAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.HubResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.HubResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.HubResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.HubResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HubData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.HubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>
    {
        public HubData(Azure.Core.AzureLocation location) { }
        public string ApiEndpoint { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat HubBillingInfo { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public int? TenantFeatures { get { throw null; } set { } }
        public string WebEndpoint { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.HubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.HubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.HubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.HubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HubResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.HubData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HubResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.HubData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource> GetAuthorizationPolicyResourceFormat(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource>> GetAuthorizationPolicyResourceFormatAsync(string authorizationPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatCollection GetAuthorizationPolicyResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource> GetConnectorResourceFormat(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource>> GetConnectorResourceFormatAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatCollection GetConnectorResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> GetInteractionResourceFormat(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>> GetInteractionResourceFormatAsync(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.InteractionResourceFormatCollection GetInteractionResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> GetKpiResourceFormat(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>> GetKpiResourceFormatAsync(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.KpiResourceFormatCollection GetKpiResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> GetLinkResourceFormat(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>> GetLinkResourceFormatAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.LinkResourceFormatCollection GetLinkResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> GetPredictionResourceFormat(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>> GetPredictionResourceFormatAsync(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.PredictionResourceFormatCollection GetPredictionResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> GetProfileResourceFormat(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>> GetProfileResourceFormatAsync(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ProfileResourceFormatCollection GetProfileResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> GetRelationshipLinkResourceFormat(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>> GetRelationshipLinkResourceFormatAsync(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatCollection GetRelationshipLinkResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> GetRelationshipResourceFormat(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>> GetRelationshipResourceFormatAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatCollection GetRelationshipResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> GetRoleAssignmentResourceFormat(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>> GetRoleAssignmentResourceFormatAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatCollection GetRoleAssignmentResourceFormats() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat> GetRoles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat> GetRolesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition> GetUploadUrlForDataImage(Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>> GetUploadUrlForDataImageAsync(Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition> GetUploadUrlForEntityTypeImage(Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>> GetUploadUrlForEntityTypeImageAsync(Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput input, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> GetViewResourceFormat(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource>> GetViewResourceFormatAsync(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ViewResourceFormatCollection GetViewResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> GetWidgetTypeResourceFormat(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>> GetWidgetTypeResourceFormatAsync(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatCollection GetWidgetTypeResourceFormats() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.HubData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.HubData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.HubData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.HubData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.HubData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> Update(Azure.ResourceManager.CustomerInsights.HubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> UpdateAsync(Azure.ResourceManager.CustomerInsights.HubData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InteractionResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>, System.Collections.IEnumerable
    {
        protected InteractionResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string interactionName, Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string interactionName, Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> Get(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> GetAll(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> GetAllAsync(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>> GetAsync(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> GetIfExists(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>> GetIfExistsAsync(string interactionName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InteractionResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>
    {
        public InteractionResourceFormatData() { }
        public string ApiEntitySetName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Attributes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence> DataSourcePrecedenceRules { get { throw null; } }
        public string DataSourceReferenceId { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.DataSourceType? DataSourceType { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.EntityType? EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition> Fields { get { throw null; } }
        public int? IdPropertiesDefaultDataSourceId { get { throw null; } }
        public System.Collections.Generic.IList<string> IdPropertyNames { get { throw null; } }
        public int? InstancesCount { get { throw null; } set { } }
        public bool? IsActivity { get { throw null; } set { } }
        public string LargeImage { get { throw null; } set { } }
        public System.DateTimeOffset? LastChangedUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> LocalizedAttributes { get { throw null; } }
        public string MediumImage { get { throw null; } set { } }
        public string NamePropertiesDefaultDataSourceName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.Participant> ParticipantProfiles { get { throw null; } }
        public string PrimaryParticipantProfilePropertyName { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaItemTypeLink { get { throw null; } set { } }
        public string SmallImage { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.Status? Status { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimestampFieldName { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InteractionResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InteractionResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string interactionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> Get(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>> GetAsync(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse> SuggestRelationshipLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>> SuggestRelationshipLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KpiResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>, System.Collections.IEnumerable
    {
        protected KpiResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kpiName, Azure.ResourceManager.CustomerInsights.KpiResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kpiName, Azure.ResourceManager.CustomerInsights.KpiResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> Get(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>> GetAsync(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> GetIfExists(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>> GetIfExistsAsync(string kpiName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KpiResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>
    {
        public KpiResourceFormatData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.KpiAlias> Aliases { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.CalculationWindowType? CalculationWindow { get { throw null; } set { } }
        public string CalculationWindowFieldName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.EntityType? EntityType { get { throw null; } set { } }
        public string EntityTypeName { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.KpiExtract> Extracts { get { throw null; } }
        public string Filter { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.KpiFunction? Function { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata> GroupByMetadata { get { throw null; } }
        public string KpiName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata> ParticipantProfilesMetadata { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.KpiThresholds ThresHolds { get { throw null; } set { } }
        public string Unit { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.KpiResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.KpiResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KpiResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KpiResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.KpiResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string kpiName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Reprocess(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ReprocessAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.KpiResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.KpiResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.KpiResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.KpiResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.KpiResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LinkResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>, System.Collections.IEnumerable
    {
        protected LinkResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string linkName, Azure.ResourceManager.CustomerInsights.LinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string linkName, Azure.ResourceManager.CustomerInsights.LinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> Get(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>> GetAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> GetIfExists(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>> GetIfExistsAsync(string linkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LinkResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>
    {
        public LinkResourceFormatData() { }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public string LinkName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping> Mappings { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.InstanceOperationType? OperationType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference> ParticipantPropertyReferences { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public bool? ReferenceOnly { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.EntityType? SourceEntityType { get { throw null; } set { } }
        public string SourceEntityTypeName { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.EntityType? TargetEntityType { get { throw null; } set { } }
        public string TargetEntityTypeName { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.LinkResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.LinkResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LinkResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.LinkResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string linkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.LinkResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.LinkResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.LinkResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.LinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.LinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PredictionResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>, System.Collections.IEnumerable
    {
        protected PredictionResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string predictionName, Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string predictionName, Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> Get(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>> GetAsync(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> GetIfExists(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>> GetIfExistsAsync(string predictionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PredictionResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>
    {
        public PredictionResourceFormatData() { }
        public bool? AutoAnalyze { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem> Grades { get { throw null; } }
        public System.Collections.Generic.IList<string> InvolvedInteractionTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> InvolvedKpiTypes { get { throw null; } }
        public System.Collections.Generic.IList<string> InvolvedRelationships { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.PredictionMappings Mappings { get { throw null; } set { } }
        public string NegativeOutcomeExpression { get { throw null; } set { } }
        public string PositiveOutcomeExpression { get { throw null; } set { } }
        public string PredictionName { get { throw null; } set { } }
        public string PrimaryProfileType { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ScopeExpression { get { throw null; } set { } }
        public string ScoreLabel { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities SystemGeneratedEntities { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PredictionResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string predictionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus> GetModelStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>> GetModelStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults> GetTrainingResults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>> GetTrainingResultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ModelStatus(Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus predictionModelStatus, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ModelStatusAsync(Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus predictionModelStatus, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProfileResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>, System.Collections.IEnumerable
    {
        protected ProfileResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string profileName, Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> Get(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> GetAll(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> GetAllAsync(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>> GetAsync(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> GetIfExists(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>> GetIfExistsAsync(string profileName, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProfileResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>
    {
        public ProfileResourceFormatData() { }
        public string ApiEntitySetName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> Attributes { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.EntityType? EntityType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition> Fields { get { throw null; } }
        public int? InstancesCount { get { throw null; } set { } }
        public string LargeImage { get { throw null; } set { } }
        public System.DateTimeOffset? LastChangedUtc { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> LocalizedAttributes { get { throw null; } }
        public string MediumImage { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaItemTypeLink { get { throw null; } set { } }
        public string SmallImage { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.StrongId> StrongIds { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string TimestampFieldName { get { throw null; } set { } }
        public string TypeName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProfileResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string profileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> Get(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>> GetAsync(string localeCode = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition> GetEnrichingKpis(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition> GetEnrichingKpisAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelationshipLinkResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>, System.Collections.IEnumerable
    {
        protected RelationshipLinkResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationshipLinkName, Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationshipLinkName, Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> Get(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>> GetAsync(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> GetIfExists(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>> GetIfExistsAsync(string relationshipLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelationshipLinkResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>
    {
        public RelationshipLinkResourceFormatData() { }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public string InteractionType { get { throw null; } set { } }
        public string LinkName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping> Mappings { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> ProfilePropertyReferences { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> RelatedProfilePropertyReferences { get { throw null; } }
        public string RelationshipGuidId { get { throw null; } }
        public string RelationshipName { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipLinkResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelationshipLinkResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string relationshipLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RelationshipResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>, System.Collections.IEnumerable
    {
        protected RelationshipResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string relationshipName, Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string relationshipName, Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> Get(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>> GetAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> GetIfExists(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>> GetIfExistsAsync(string relationshipName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RelationshipResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>
    {
        public RelationshipResourceFormatData() { }
        public Azure.ResourceManager.CustomerInsights.Models.CardinalityType? Cardinality { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public System.DateTimeOffset? ExpiryDateTimeUtc { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition> Fields { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping> LookupMappings { get { throw null; } }
        public string ProfileType { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string RelatedProfileType { get { throw null; } set { } }
        public string RelationshipGuidId { get { throw null; } }
        public string RelationshipName { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RelationshipResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string relationshipName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RoleAssignmentResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>, System.Collections.IEnumerable
    {
        protected RoleAssignmentResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string assignmentName, Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> Get(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>> GetAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> GetIfExists(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>> GetIfExistsAsync(string assignmentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RoleAssignmentResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>
    {
        public RoleAssignmentResourceFormatData() { }
        public string AssignmentName { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription ConflationPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Connectors { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Interactions { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Kpis { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Links { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal> Principals { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Profiles { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription RelationshipLinks { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Relationships { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.RoleType? Role { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription RoleAssignments { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription SasPolicies { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Segments { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription Views { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription WidgetTypes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleAssignmentResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RoleAssignmentResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string assignmentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ViewResourceFormatCollection : Azure.ResourceManager.ArmCollection
    {
        protected ViewResourceFormatCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CustomerInsights.ViewResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string viewName, Azure.ResourceManager.CustomerInsights.ViewResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> Get(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> GetAll(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> GetAllAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource>> GetAsync(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> GetIfExists(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource>> GetIfExistsAsync(string viewName, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ViewResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>
    {
        public ViewResourceFormatData() { }
        public System.DateTimeOffset? Changed { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Definition { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string UserId { get { throw null; } set { } }
        public string ViewName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ViewResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ViewResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ViewResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ViewResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.ViewResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string viewName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> Get(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource>> GetAsync(string userId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.ViewResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.ViewResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.ViewResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ViewResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CustomerInsights.ViewResourceFormatData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WidgetTypeResourceFormatCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>, System.Collections.IEnumerable
    {
        protected WidgetTypeResourceFormatCollection() { }
        public virtual Azure.Response<bool> Exists(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> Get(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>> GetAsync(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> GetIfExists(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>> GetIfExistsAsync(string widgetTypeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WidgetTypeResourceFormatData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>
    {
        public WidgetTypeResourceFormatData() { }
        public System.DateTimeOffset? Changed { get { throw null; } }
        public System.DateTimeOffset? Created { get { throw null; } }
        public string Definition { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public System.Uri ImageUri { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public string WidgetTypeName { get { throw null; } }
        public string WidgetVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WidgetTypeResourceFormatResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WidgetTypeResourceFormatResource() { }
        public virtual Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string hubName, string widgetTypeName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.CustomerInsights.Mocking
{
    public partial class MockableCustomerInsightsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableCustomerInsightsArmClient() { }
        public virtual Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatResource GetAuthorizationPolicyResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatResource GetConnectorMappingResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatResource GetConnectorResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.HubResource GetHubResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.InteractionResourceFormatResource GetInteractionResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.KpiResourceFormatResource GetKpiResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.LinkResourceFormatResource GetLinkResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.PredictionResourceFormatResource GetPredictionResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ProfileResourceFormatResource GetProfileResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatResource GetRelationshipLinkResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatResource GetRelationshipResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatResource GetRoleAssignmentResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.ViewResourceFormatResource GetViewResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatResource GetWidgetTypeResourceFormatResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableCustomerInsightsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCustomerInsightsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource> GetHub(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.CustomerInsights.HubResource>> GetHubAsync(string hubName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.CustomerInsights.HubCollection GetHubs() { throw null; }
    }
    public partial class MockableCustomerInsightsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCustomerInsightsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.CustomerInsights.HubResource> GetHubs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.CustomerInsights.HubResource> GetHubsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CustomerInsights.Models
{
    public static partial class ArmCustomerInsightsModelFactory
    {
        public static Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy AuthorizationPolicy(string policyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.PermissionType> permissions = null, string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.AuthorizationPolicyResourceFormatData AuthorizationPolicyResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string policyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.PermissionType> permissions = null, string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition CanonicalProfileDefinition(int? canonicalProfileId = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem> properties = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem CanonicalProfileDefinitionPropertiesItem(string profileName = null, string profilePropertyName = null, int? rank = default(int?), Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType? valueType = default(Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType?), string value = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat ConnectorMappingFormat(Azure.ResourceManager.CustomerInsights.Models.FormatType formatType = default(Azure.ResourceManager.CustomerInsights.Models.FormatType), string columnDelimiter = null, string acceptLanguage = null, string quoteCharacter = null, string quoteEscapeCharacter = null, string arraySeparator = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ConnectorMappingResourceFormatData ConnectorMappingResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string connectorName = null, Azure.ResourceManager.CustomerInsights.Models.ConnectorType? connectorType = default(Azure.ResourceManager.CustomerInsights.Models.ConnectorType?), System.DateTimeOffset? created = default(System.DateTimeOffset?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), Azure.ResourceManager.CustomerInsights.Models.EntityType? entityType = default(Azure.ResourceManager.CustomerInsights.Models.EntityType?), string entityTypeName = null, string connectorMappingName = null, string displayName = null, string description = null, string dataFormatId = null, Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties mappingProperties = null, System.DateTimeOffset? nextRunOn = default(System.DateTimeOffset?), string runId = null, Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingState? state = default(Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingState?), System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ConnectorResourceFormatData ConnectorResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? connectorId = default(int?), string connectorName = null, Azure.ResourceManager.CustomerInsights.Models.ConnectorType? connectorType = default(Azure.ResourceManager.CustomerInsights.Models.ConnectorType?), string displayName = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> connectorProperties = null, System.DateTimeOffset? created = default(System.DateTimeOffset?), System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), Azure.ResourceManager.CustomerInsights.Models.ConnectorState? state = default(Azure.ResourceManager.CustomerInsights.Models.ConnectorState?), System.Guid? tenantId = default(System.Guid?), bool? isInternal = default(bool?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence DataSourcePrecedence(int? precedence = default(int?), string name = null, Azure.ResourceManager.CustomerInsights.Models.DataSourceType? dataSourceType = default(Azure.ResourceManager.CustomerInsights.Models.DataSourceType?), Azure.ResourceManager.CustomerInsights.Models.Status? status = default(Azure.ResourceManager.CustomerInsights.Models.Status?), int? id = default(int?), string dataSourceReferenceId = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.HubData HubData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string apiEndpoint = null, string webEndpoint = null, string provisioningState = null, int? tenantFeatures = default(int?), Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat hubBillingInfo = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.ImageDefinition ImageDefinition(bool? imageExists = default(bool?), System.Uri contentUri = null, string relativePath = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.InteractionResourceFormatData InteractionResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> attributes = null, System.Collections.Generic.IDictionary<string, string> description = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> localizedAttributes = null, string smallImage = null, string mediumImage = null, string largeImage = null, string apiEntitySetName = null, Azure.ResourceManager.CustomerInsights.Models.EntityType? entityType = default(Azure.ResourceManager.CustomerInsights.Models.EntityType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition> fields = null, int? instancesCount = default(int?), System.DateTimeOffset? lastChangedUtc = default(System.DateTimeOffset?), Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), string schemaItemTypeLink = null, System.Guid? tenantId = default(System.Guid?), string timestampFieldName = null, string typeName = null, System.Collections.Generic.IEnumerable<string> idPropertyNames = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.Participant> participantProfiles = null, string primaryParticipantProfilePropertyName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence> dataSourcePrecedenceRules = null, bool? isActivity = default(bool?), string namePropertiesDefaultDataSourceName = null, Azure.ResourceManager.CustomerInsights.Models.DataSourceType? dataSourceType = default(Azure.ResourceManager.CustomerInsights.Models.DataSourceType?), Azure.ResourceManager.CustomerInsights.Models.Status? status = default(Azure.ResourceManager.CustomerInsights.Models.Status?), int? idPropertiesDefaultDataSourceId = default(int?), string dataSourceReferenceId = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.KpiDefinition KpiDefinition(Azure.ResourceManager.CustomerInsights.Models.EntityType entityType = Azure.ResourceManager.CustomerInsights.Models.EntityType.None, string entityTypeName = null, System.Guid? tenantId = default(System.Guid?), string kpiName = null, System.Collections.Generic.IReadOnlyDictionary<string, string> displayName = null, System.Collections.Generic.IReadOnlyDictionary<string, string> description = null, Azure.ResourceManager.CustomerInsights.Models.CalculationWindowType calculationWindow = Azure.ResourceManager.CustomerInsights.Models.CalculationWindowType.Lifetime, string calculationWindowFieldName = null, Azure.ResourceManager.CustomerInsights.Models.KpiFunction function = Azure.ResourceManager.CustomerInsights.Models.KpiFunction.None, string expression = null, string unit = null, string filter = null, System.Collections.Generic.IEnumerable<string> groupBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata> groupByMetadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata> participantProfilesMetadata = null, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), Azure.ResourceManager.CustomerInsights.Models.KpiThresholds thresHolds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiAlias> aliases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiExtract> extracts = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata KpiGroupByMetadata(System.Collections.Generic.IReadOnlyDictionary<string, string> displayName = null, string fieldName = null, string fieldType = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata KpiParticipantProfilesMetadata(string typeName = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.KpiResourceFormatData KpiResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CustomerInsights.Models.EntityType? entityType = default(Azure.ResourceManager.CustomerInsights.Models.EntityType?), string entityTypeName = null, System.Guid? tenantId = default(System.Guid?), string kpiName = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IDictionary<string, string> description = null, Azure.ResourceManager.CustomerInsights.Models.CalculationWindowType? calculationWindow = default(Azure.ResourceManager.CustomerInsights.Models.CalculationWindowType?), string calculationWindowFieldName = null, Azure.ResourceManager.CustomerInsights.Models.KpiFunction? function = default(Azure.ResourceManager.CustomerInsights.Models.KpiFunction?), string expression = null, string unit = null, string filter = null, System.Collections.Generic.IEnumerable<string> groupBy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata> groupByMetadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata> participantProfilesMetadata = null, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), Azure.ResourceManager.CustomerInsights.Models.KpiThresholds thresHolds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiAlias> aliases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.KpiExtract> extracts = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.LinkResourceFormatData LinkResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? tenantId = default(System.Guid?), string linkName = null, Azure.ResourceManager.CustomerInsights.Models.EntityType? sourceEntityType = default(Azure.ResourceManager.CustomerInsights.Models.EntityType?), Azure.ResourceManager.CustomerInsights.Models.EntityType? targetEntityType = default(Azure.ResourceManager.CustomerInsights.Models.EntityType?), string sourceEntityTypeName = null, string targetEntityTypeName = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IDictionary<string, string> description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping> mappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference> participantPropertyReferences = null, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), bool? referenceOnly = default(bool?), Azure.ResourceManager.CustomerInsights.Models.InstanceOperationType? operationType = default(Azure.ResourceManager.CustomerInsights.Models.InstanceOperationType?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition PredictionDistributionDefinition(long? totalPositives = default(long?), long? totalNegatives = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem> distributions = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem PredictionDistributionDefinitionDistributionsItem(int? scoreThreshold = default(int?), long? positives = default(long?), long? negatives = default(long?), long? positivesAboveThreshold = default(long?), long? negativesAboveThreshold = default(long?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus PredictionModelStatus(System.Guid? tenantId = default(System.Guid?), string predictionName = null, string predictionGuidId = null, Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle status = default(Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle), string message = null, int? trainingSetCount = default(int?), int? testSetCount = default(int?), int? validationSetCount = default(int?), decimal? trainingAccuracy = default(decimal?), int? signalsUsed = default(int?), string modelVersion = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.PredictionResourceFormatData PredictionResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> description = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IEnumerable<string> involvedInteractionTypes = null, System.Collections.Generic.IEnumerable<string> involvedKpiTypes = null, System.Collections.Generic.IEnumerable<string> involvedRelationships = null, string negativeOutcomeExpression = null, string positiveOutcomeExpression = null, string primaryProfileType = null, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), string predictionName = null, string scopeExpression = null, System.Guid? tenantId = default(System.Guid?), bool? autoAnalyze = default(bool?), Azure.ResourceManager.CustomerInsights.Models.PredictionMappings mappings = null, string scoreLabel = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem> grades = null, Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities systemGeneratedEntities = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities PredictionSystemGeneratedEntities(System.Collections.Generic.IEnumerable<string> generatedInteractionTypes = null, System.Collections.Generic.IEnumerable<string> generatedLinks = null, System.Collections.Generic.IReadOnlyDictionary<string, string> generatedKpis = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults PredictionTrainingResults(System.Guid? tenantId = default(System.Guid?), string scoreName = null, Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition predictionDistribution = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition> canonicalProfiles = null, long? primaryProfileInstanceCount = default(long?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ProfileResourceFormatData ProfileResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IList<string>> attributes = null, System.Collections.Generic.IDictionary<string, string> description = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> localizedAttributes = null, string smallImage = null, string mediumImage = null, string largeImage = null, string apiEntitySetName = null, Azure.ResourceManager.CustomerInsights.Models.EntityType? entityType = default(Azure.ResourceManager.CustomerInsights.Models.EntityType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition> fields = null, int? instancesCount = default(int?), System.DateTimeOffset? lastChangedUtc = default(System.DateTimeOffset?), Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), string schemaItemTypeLink = null, System.Guid? tenantId = default(System.Guid?), string timestampFieldName = null, string typeName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.StrongId> strongIds = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition PropertyDefinition(string arrayValueSeparator = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat> enumValidValues = null, string fieldName = null, string fieldType = null, bool? isArray = default(bool?), bool? isEnum = default(bool?), bool? isFlagEnum = default(bool?), bool? isImage = default(bool?), bool? isLocalizedString = default(bool?), bool? isName = default(bool?), bool? isRequired = default(bool?), string propertyId = null, string schemaItemPropLink = null, int? maxLength = default(int?), bool? isAvailableInGraph = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence> dataSourcePrecedenceRules = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.RelationshipLinkResourceFormatData RelationshipLinkResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IDictionary<string, string> description = null, string interactionType = null, string linkName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping> mappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> profilePropertyReferences = null, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> relatedProfilePropertyReferences = null, string relationshipName = null, string relationshipGuidId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.RelationshipResourceFormatData RelationshipResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.CustomerInsights.Models.CardinalityType? cardinality = default(Azure.ResourceManager.CustomerInsights.Models.CardinalityType?), System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IDictionary<string, string> description = null, System.DateTimeOffset? expiryDateTimeUtc = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition> fields = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping> lookupMappings = null, string profileType = null, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), string relationshipName = null, string relatedProfileType = null, string relationshipGuidId = null, System.Guid? tenantId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup RelationshipsLookup(string profileName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> profilePropertyReferences = null, string relatedProfileName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> relatedProfilePropertyReferences = null, string existingRelationshipName = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.RoleAssignmentResourceFormatData RoleAssignmentResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? tenantId = default(System.Guid?), string assignmentName = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Collections.Generic.IDictionary<string, string> description = null, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState?), Azure.ResourceManager.CustomerInsights.Models.RoleType? role = default(Azure.ResourceManager.CustomerInsights.Models.RoleType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal> principals = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription profiles = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription interactions = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription links = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription kpis = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription sasPolicies = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription connectors = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription views = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription relationshipLinks = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription relationships = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription widgetTypes = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription roleAssignments = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription conflationPolicies = null, Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription segments = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat RoleResourceFormat(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string roleName = null, string description = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse SuggestRelationshipLinksResponse(string interactionName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup> suggestedRelationships = null) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.ViewResourceFormatData ViewResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string viewName = null, string userId = null, System.Guid? tenantId = default(System.Guid?), System.Collections.Generic.IDictionary<string, string> displayName = null, string definition = null, System.DateTimeOffset? changed = default(System.DateTimeOffset?), System.DateTimeOffset? created = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.WidgetTypeResourceFormatData WidgetTypeResourceFormatData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string widgetTypeName = null, string definition = null, string description = null, System.Collections.Generic.IDictionary<string, string> displayName = null, System.Uri imageUri = null, System.Guid? tenantId = default(System.Guid?), string widgetVersion = null, System.DateTimeOffset? changed = default(System.DateTimeOffset?), System.DateTimeOffset? created = default(System.DateTimeOffset?)) { throw null; }
    }
    public partial class AssignmentPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal>
    {
        public AssignmentPrincipal(string principalId, string principalType) { }
        public string PrincipalId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PrincipalMetadata { get { throw null; } }
        public string PrincipalType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AssignmentPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AuthorizationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>
    {
        internal AuthorizationPolicy() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.PermissionType> Permissions { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.AuthorizationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CalculationWindowType
    {
        Lifetime = 0,
        Hour = 1,
        Day = 2,
        Week = 3,
        Month = 4,
    }
    public partial class CanonicalProfileDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition>
    {
        internal CanonicalProfileDefinition() { }
        public int? CanonicalProfileId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem> Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CanonicalProfileDefinitionPropertiesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem>
    {
        internal CanonicalProfileDefinitionPropertiesItem() { }
        public string ProfileName { get { throw null; } }
        public string ProfilePropertyName { get { throw null; } }
        public int? Rank { get { throw null; } }
        public string Value { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType? ValueType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinitionPropertiesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CanonicalPropertyValueType : System.IEquatable<Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CanonicalPropertyValueType(string value) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType Categorical { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType DerivedCategorical { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType DerivedNumeric { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType Numeric { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType left, Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType left, Azure.ResourceManager.CustomerInsights.Models.CanonicalPropertyValueType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum CardinalityType
    {
        OneToOne = 0,
        OneToMany = 1,
        ManyToMany = 2,
    }
    public enum CompletionOperationType
    {
        DoNothing = 0,
        DeleteFile = 1,
        MoveFile = 2,
    }
    public partial class ConnectorMappingAvailability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability>
    {
        public ConnectorMappingAvailability(int interval) { }
        public Azure.ResourceManager.CustomerInsights.Models.FrequencyType? Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorMappingCompleteOperation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation>
    {
        public ConnectorMappingCompleteOperation() { }
        public Azure.ResourceManager.CustomerInsights.Models.CompletionOperationType? CompletionOperationType { get { throw null; } set { } }
        public string DestinationFolder { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorMappingErrorManagement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement>
    {
        public ConnectorMappingErrorManagement(Azure.ResourceManager.CustomerInsights.Models.ErrorManagementType errorManagementType) { }
        public int? ErrorLimit { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ErrorManagementType ErrorManagementType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorMappingFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat>
    {
        public ConnectorMappingFormat() { }
        public string AcceptLanguage { get { throw null; } set { } }
        public string ArraySeparator { get { throw null; } set { } }
        public string ColumnDelimiter { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.FormatType FormatType { get { throw null; } }
        public string QuoteCharacter { get { throw null; } set { } }
        public string QuoteEscapeCharacter { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectorMappingProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties>
    {
        public ConnectorMappingProperties(Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement errorManagement, Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat format, Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability availability, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure> structure, Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation completeOperation) { }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingAvailability Availability { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingCompleteOperation CompleteOperation { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingErrorManagement ErrorManagement { get { throw null; } set { } }
        public string FileFilter { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingFormat Format { get { throw null; } set { } }
        public bool? HasHeader { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure> Structure { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ConnectorMappingState
    {
        Creating = 0,
        Created = 1,
        Failed = 2,
        Ready = 3,
        Running = 4,
        Stopped = 5,
        Expiring = 6,
    }
    public partial class ConnectorMappingStructure : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure>
    {
        public ConnectorMappingStructure(string propertyName, string columnName) { }
        public string ColumnName { get { throw null; } set { } }
        public string CustomFormatSpecifier { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } set { } }
        public string PropertyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ConnectorMappingStructure>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ConnectorState
    {
        Creating = 0,
        Created = 1,
        Ready = 2,
        Expiring = 3,
        Deleting = 4,
        Failed = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConnectorType : System.IEquatable<Azure.ResourceManager.CustomerInsights.Models.ConnectorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConnectorType(string value) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.ConnectorType AzureBlob { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ConnectorType CRM { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ConnectorType ExchangeOnline { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ConnectorType None { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ConnectorType Outbound { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ConnectorType Salesforce { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CustomerInsights.Models.ConnectorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CustomerInsights.Models.ConnectorType left, Azure.ResourceManager.CustomerInsights.Models.ConnectorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CustomerInsights.Models.ConnectorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CustomerInsights.Models.ConnectorType left, Azure.ResourceManager.CustomerInsights.Models.ConnectorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataSourcePrecedence : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence>
    {
        internal DataSourcePrecedence() { }
        public string DataSourceReferenceId { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.DataSourceType? DataSourceType { get { throw null; } }
        public int? Id { get { throw null; } }
        public string Name { get { throw null; } }
        public int? Precedence { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.Status? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataSourceType : System.IEquatable<Azure.ResourceManager.CustomerInsights.Models.DataSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataSourceType(string value) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.DataSourceType Connector { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.DataSourceType LinkInteraction { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.DataSourceType SystemDefault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CustomerInsights.Models.DataSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CustomerInsights.Models.DataSourceType left, Azure.ResourceManager.CustomerInsights.Models.DataSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CustomerInsights.Models.DataSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CustomerInsights.Models.DataSourceType left, Azure.ResourceManager.CustomerInsights.Models.DataSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum EntityType
    {
        None = 0,
        Profile = 1,
        Interaction = 2,
        Relationship = 3,
    }
    public enum ErrorManagementType
    {
        RejectAndContinue = 0,
        StopImport = 1,
        RejectUntilLimit = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FormatType : System.IEquatable<Azure.ResourceManager.CustomerInsights.Models.FormatType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FormatType(string value) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.FormatType TextFormat { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CustomerInsights.Models.FormatType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CustomerInsights.Models.FormatType left, Azure.ResourceManager.CustomerInsights.Models.FormatType right) { throw null; }
        public static implicit operator Azure.ResourceManager.CustomerInsights.Models.FormatType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CustomerInsights.Models.FormatType left, Azure.ResourceManager.CustomerInsights.Models.FormatType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum FrequencyType
    {
        Minute = 0,
        Hour = 1,
        Day = 2,
        Week = 3,
        Month = 4,
    }
    public partial class GetImageUploadUrlInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput>
    {
        public GetImageUploadUrlInput() { }
        public string EntityType { get { throw null; } set { } }
        public string EntityTypeName { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.GetImageUploadUrlInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HubBillingInfoFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat>
    {
        public HubBillingInfoFormat() { }
        public int? MaxUnits { get { throw null; } set { } }
        public int? MinUnits { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.HubBillingInfoFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>
    {
        internal ImageDefinition() { }
        public System.Uri ContentUri { get { throw null; } }
        public bool? ImageExists { get { throw null; } }
        public string RelativePath { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ImageDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ImageDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ImageDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum InstanceOperationType
    {
        Upsert = 0,
        Delete = 1,
    }
    public partial class KpiAlias : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiAlias>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiAlias>
    {
        public KpiAlias(string aliasName, string expression) { }
        public string AliasName { get { throw null; } set { } }
        public string Expression { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiAlias System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiAlias>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiAlias>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiAlias System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiAlias>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiAlias>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiAlias>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KpiDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition>
    {
        internal KpiDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.KpiAlias> Aliases { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.CalculationWindowType CalculationWindow { get { throw null; } }
        public string CalculationWindowFieldName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DisplayName { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.EntityType EntityType { get { throw null; } }
        public string EntityTypeName { get { throw null; } }
        public string Expression { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.KpiExtract> Extracts { get { throw null; } }
        public string Filter { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.KpiFunction Function { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GroupBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata> GroupByMetadata { get { throw null; } }
        public string KpiName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata> ParticipantProfilesMetadata { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.KpiThresholds ThresHolds { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KpiExtract : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiExtract>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiExtract>
    {
        public KpiExtract(string extractName, string expression) { }
        public string Expression { get { throw null; } set { } }
        public string ExtractName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiExtract System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiExtract>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiExtract>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiExtract System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiExtract>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiExtract>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiExtract>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum KpiFunction
    {
        None = 0,
        Sum = 1,
        Avg = 2,
        Min = 3,
        Max = 4,
        Last = 5,
        Count = 6,
        CountDistinct = 7,
    }
    public partial class KpiGroupByMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata>
    {
        internal KpiGroupByMetadata() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> DisplayName { get { throw null; } }
        public string FieldName { get { throw null; } }
        public string FieldType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiGroupByMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KpiParticipantProfilesMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata>
    {
        internal KpiParticipantProfilesMetadata() { }
        public string TypeName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiParticipantProfilesMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KpiThresholds : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiThresholds>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiThresholds>
    {
        public KpiThresholds(decimal lowerLimit, decimal upperLimit, bool increasingKpi) { }
        public bool IncreasingKpi { get { throw null; } set { } }
        public decimal LowerLimit { get { throw null; } set { } }
        public decimal UpperLimit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiThresholds System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiThresholds>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.KpiThresholds>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.KpiThresholds System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiThresholds>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiThresholds>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.KpiThresholds>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LinkType
    {
        UpdateAlways = 0,
        CopyIfNull = 1,
    }
    public partial class Participant : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.Participant>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.Participant>
    {
        public Participant(string profileTypeName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference> participantPropertyReferences, string participantName) { }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public string ParticipantName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference> ParticipantPropertyReferences { get { throw null; } }
        public string ProfileTypeName { get { throw null; } set { } }
        public string Role { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.Participant System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.Participant>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.Participant>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.Participant System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.Participant>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.Participant>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.Participant>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParticipantProfilePropertyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference>
    {
        public ParticipantProfilePropertyReference(string interactionPropertyName, string profilePropertyName) { }
        public string InteractionPropertyName { get { throw null; } set { } }
        public string ProfilePropertyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ParticipantPropertyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference>
    {
        public ParticipantPropertyReference(string sourcePropertyName, string targetPropertyName) { }
        public string SourcePropertyName { get { throw null; } set { } }
        public string TargetPropertyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ParticipantPropertyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum PermissionType
    {
        Read = 0,
        Write = 1,
        Manage = 2,
    }
    public partial class PredictionDistributionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition>
    {
        internal PredictionDistributionDefinition() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem> Distributions { get { throw null; } }
        public long? TotalNegatives { get { throw null; } }
        public long? TotalPositives { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionDistributionDefinitionDistributionsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem>
    {
        internal PredictionDistributionDefinitionDistributionsItem() { }
        public long? Negatives { get { throw null; } }
        public long? NegativesAboveThreshold { get { throw null; } }
        public long? Positives { get { throw null; } }
        public long? PositivesAboveThreshold { get { throw null; } }
        public int? ScoreThreshold { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinitionDistributionsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionGradesItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem>
    {
        public PredictionGradesItem() { }
        public string GradeName { get { throw null; } set { } }
        public int? MaxScoreThreshold { get { throw null; } set { } }
        public int? MinScoreThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionGradesItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionMappings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionMappings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionMappings>
    {
        public PredictionMappings(string score, string grade, string reason) { }
        public string Grade { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
        public string Score { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionMappings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionMappings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionMappings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionMappings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionMappings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionMappings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionMappings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PredictionModelLifeCycle : System.IEquatable<Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PredictionModelLifeCycle(string value) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Active { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Deleted { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Discovering { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Evaluating { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle EvaluatingFailed { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Failed { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Featuring { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle FeaturingFailed { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle HumanIntervention { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle New { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle PendingDiscovering { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle PendingFeaturing { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle PendingModelConfirmation { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle PendingTraining { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Provisioning { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle ProvisioningFailed { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Training { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle TrainingFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle left, Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle right) { throw null; }
        public static implicit operator Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle left, Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PredictionModelStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>
    {
        public PredictionModelStatus(Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle status) { }
        public string Message { get { throw null; } }
        public string ModelVersion { get { throw null; } }
        public string PredictionGuidId { get { throw null; } }
        public string PredictionName { get { throw null; } }
        public int? SignalsUsed { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.PredictionModelLifeCycle Status { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } }
        public int? TestSetCount { get { throw null; } }
        public decimal? TrainingAccuracy { get { throw null; } }
        public int? TrainingSetCount { get { throw null; } }
        public int? ValidationSetCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionModelStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionSystemGeneratedEntities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities>
    {
        internal PredictionSystemGeneratedEntities() { }
        public System.Collections.Generic.IReadOnlyList<string> GeneratedInteractionTypes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> GeneratedKpis { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> GeneratedLinks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionSystemGeneratedEntities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PredictionTrainingResults : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>
    {
        internal PredictionTrainingResults() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.CanonicalProfileDefinition> CanonicalProfiles { get { throw null; } }
        public Azure.ResourceManager.CustomerInsights.Models.PredictionDistributionDefinition PredictionDistribution { get { throw null; } }
        public long? PrimaryProfileInstanceCount { get { throw null; } }
        public string ScoreName { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PredictionTrainingResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProfileEnumValidValuesFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat>
    {
        public ProfileEnumValidValuesFormat() { }
        public System.Collections.Generic.IDictionary<string, string> LocalizedValueNames { get { throw null; } }
        public int? Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PropertyDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition>
    {
        public PropertyDefinition(string fieldName, string fieldType) { }
        public string ArrayValueSeparator { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.DataSourcePrecedence> DataSourcePrecedenceRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.ProfileEnumValidValuesFormat> EnumValidValues { get { throw null; } }
        public string FieldName { get { throw null; } set { } }
        public string FieldType { get { throw null; } set { } }
        public bool? IsArray { get { throw null; } set { } }
        public bool? IsAvailableInGraph { get { throw null; } set { } }
        public bool? IsEnum { get { throw null; } set { } }
        public bool? IsFlagEnum { get { throw null; } set { } }
        public bool? IsImage { get { throw null; } set { } }
        public bool? IsLocalizedString { get { throw null; } set { } }
        public bool? IsName { get { throw null; } set { } }
        public bool? IsRequired { get { throw null; } set { } }
        public int? MaxLength { get { throw null; } set { } }
        public string PropertyId { get { throw null; } set { } }
        public string SchemaItemPropLink { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.PropertyDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.CustomerInsights.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ProvisioningState Expiring { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ProvisioningState HumanIntervention { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState left, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.CustomerInsights.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CustomerInsights.Models.ProvisioningState left, Azure.ResourceManager.CustomerInsights.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelationshipLinkFieldMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping>
    {
        public RelationshipLinkFieldMapping(string interactionFieldName, string relationshipFieldName) { }
        public string InteractionFieldName { get { throw null; } set { } }
        public Azure.ResourceManager.CustomerInsights.Models.LinkType? LinkType { get { throw null; } set { } }
        public string RelationshipFieldName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipLinkFieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipsLookup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup>
    {
        internal RelationshipsLookup() { }
        public string ExistingRelationshipName { get { throw null; } }
        public string ProfileName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> ProfilePropertyReferences { get { throw null; } }
        public string RelatedProfileName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.ParticipantProfilePropertyReference> RelatedProfilePropertyReferences { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipTypeFieldMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping>
    {
        public RelationshipTypeFieldMapping(string profileFieldName, string relatedProfileKeyProperty) { }
        public string ProfileFieldName { get { throw null; } set { } }
        public string RelatedProfileKeyProperty { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RelationshipTypeMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping>
    {
        public RelationshipTypeMapping(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping> fieldMappings) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeFieldMapping> FieldMappings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RelationshipTypeMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSetDescription : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription>
    {
        public ResourceSetDescription() { }
        public System.Collections.Generic.IList<string> Elements { get { throw null; } }
        public System.Collections.Generic.IList<string> Exceptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.ResourceSetDescription>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RoleResourceFormat : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat>
    {
        public RoleResourceFormat() { }
        public string Description { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.RoleResourceFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RoleType
    {
        Admin = 0,
        Reader = 1,
        ManageAdmin = 2,
        ManageReader = 3,
        DataAdmin = 4,
        DataReader = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Status : System.IEquatable<Azure.ResourceManager.CustomerInsights.Models.Status>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Status(string value) { throw null; }
        public static Azure.ResourceManager.CustomerInsights.Models.Status Active { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.Status Deleted { get { throw null; } }
        public static Azure.ResourceManager.CustomerInsights.Models.Status None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CustomerInsights.Models.Status other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CustomerInsights.Models.Status left, Azure.ResourceManager.CustomerInsights.Models.Status right) { throw null; }
        public static implicit operator Azure.ResourceManager.CustomerInsights.Models.Status (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CustomerInsights.Models.Status left, Azure.ResourceManager.CustomerInsights.Models.Status right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StrongId : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.StrongId>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.StrongId>
    {
        public StrongId(System.Collections.Generic.IEnumerable<string> keyPropertyNames, string strongIdName) { }
        public System.Collections.Generic.IDictionary<string, string> Description { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayName { get { throw null; } }
        public System.Collections.Generic.IList<string> KeyPropertyNames { get { throw null; } }
        public string StrongIdName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.StrongId System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.StrongId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.StrongId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.StrongId System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.StrongId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.StrongId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.StrongId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SuggestRelationshipLinksResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>
    {
        internal SuggestRelationshipLinksResponse() { }
        public string InteractionName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CustomerInsights.Models.RelationshipsLookup> SuggestedRelationships { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.SuggestRelationshipLinksResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TypePropertiesMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping>
    {
        public TypePropertiesMapping(string sourcePropertyName, string targetPropertyName) { }
        public Azure.ResourceManager.CustomerInsights.Models.LinkType? LinkType { get { throw null; } set { } }
        public string SourcePropertyName { get { throw null; } set { } }
        public string TargetPropertyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CustomerInsights.Models.TypePropertiesMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
