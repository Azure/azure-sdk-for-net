namespace Azure.ResourceManager.Purview
{
    public partial class AccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.AccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.AccountResource>, System.Collections.IEnumerable
    {
        protected AccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.AccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.AccountResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.AccountResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.AccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.AccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.AccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.AccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.AccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.AccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.AccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>
    {
        public AccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus AccountStatus { get { throw null; } }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultDomain { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewIngestionStorage IngestionStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? ManagedEventHubState { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources ManagedResources { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? ManagedResourcesPublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountMergeInfo MergeInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.TenantEndpointState? TenantEndpointState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.AccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.AccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.AccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.AccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.AccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccountResource() { }
        public virtual Azure.ResourceManager.Purview.AccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus> AccountGet(Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>> AccountGetAsync(Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddRootCollectionAdmin(Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddRootCollectionAdminAsync(Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.KafkaConfigurationResource> GetKafkaConfiguration(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.KafkaConfigurationResource>> GetKafkaConfigurationAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.KafkaConfigurationCollection GetKafkaConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PrivateLinkResource> GetPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PrivateLinkResource>> GetPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Purview.AccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.AccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.AccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.AccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.AccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.AccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.AccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult> UpdateStatus(Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>> UpdateStatusAsync(Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerPurviewContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPurviewContext() { }
        public static Azure.ResourceManager.Purview.AzureResourceManagerPurviewContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class KafkaConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.KafkaConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.KafkaConfigurationResource>, System.Collections.IEnumerable
    {
        protected KafkaConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.KafkaConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kafkaConfigurationName, Azure.ResourceManager.Purview.KafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.KafkaConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kafkaConfigurationName, Azure.ResourceManager.Purview.KafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.KafkaConfigurationResource> Get(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.KafkaConfigurationResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.KafkaConfigurationResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.KafkaConfigurationResource>> GetAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.KafkaConfigurationResource> GetIfExists(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.KafkaConfigurationResource>> GetIfExistsAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.KafkaConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.KafkaConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.KafkaConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.KafkaConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KafkaConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.KafkaConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>
    {
        public KafkaConfigurationData() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewCredentials Credentials { get { throw null; } set { } }
        public string EventHubPartitionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType? EventHubType { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewEventStreamingState? EventStreamingState { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewEventStreamingType? EventStreamingType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.KafkaConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.KafkaConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KafkaConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.KafkaConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KafkaConfigurationResource() { }
        public virtual Azure.ResourceManager.Purview.KafkaConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string kafkaConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.KafkaConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.KafkaConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Purview.KafkaConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.KafkaConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.KafkaConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.KafkaConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.KafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.KafkaConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.KafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.PrivateLinkResource> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.PrivateLinkResource>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public static partial class PurviewExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult> CheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.UsageList> Get(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> Get(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.AccountResource> GetAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> GetAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.AccountResource GetAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.AccountCollection GetAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Purview.AccountResource> GetAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Purview.AccountResource> GetAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.UsageList>> GetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> GetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.KafkaConfigurationResource GetKafkaConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response Remove(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RemoveAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> Set(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> SetAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus> SubscriptionGet(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>> SubscriptionGetAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>
    {
        public PurviewPrivateEndpointConnectionData() { }
        public string PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>
    {
        internal PurviewPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Purview.Mocking
{
    public partial class MockablePurviewArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePurviewArmClient() { }
        public virtual Azure.ResourceManager.Purview.AccountResource GetAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Purview.KafkaConfigurationResource GetKafkaConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Purview.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Purview.PrivateLinkResource GetPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePurviewResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePurviewResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.AccountResource> GetAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.AccountResource>> GetAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.AccountCollection GetAccounts() { throw null; }
    }
    public partial class MockablePurviewSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePurviewSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult> CheckNameAvailability(Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>> CheckNameAvailabilityAsync(Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.UsageList> Get(string location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.AccountResource> GetAccounts(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.AccountResource> GetAccountsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.UsageList>> GetAsync(string location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus> SubscriptionGet(string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>> SubscriptionGetAsync(string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePurviewTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePurviewTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> Get(string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> GetAsync(string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Remove(string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveAsync(string scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> Set(Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> SetAsync(Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Purview.Models
{
    public partial class AccountMergeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountMergeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountMergeInfo>
    {
        public AccountMergeInfo() { }
        public string AccountLocation { get { throw null; } }
        public string AccountName { get { throw null; } }
        public string AccountResourceGroupName { get { throw null; } }
        public string AccountSubscriptionId { get { throw null; } }
        public bool? Deprovisioned { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.MergeStatus? MergeStatus { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.MergeAccountType? TypeOfAccount { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.AccountMergeInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.AccountMergeInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.AccountMergeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountMergeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountMergeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.AccountMergeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountMergeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountMergeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountMergeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPatch>
    {
        public AccountPatch() { }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus AccountStatus { get { throw null; } }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultDomain { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.Identity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewIngestionStorage IngestionStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? ManagedEventHubState { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources ManagedResources { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? ManagedResourcesPublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.AccountMergeInfo MergeInfo { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.TenantEndpointState? TenantEndpointState { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.AccountPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.AccountPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.AccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.AccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountPropertiesAccountStatus : Azure.ResourceManager.Purview.Models.PurviewAccountStatus, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus>
    {
        internal AccountPropertiesAccountStatus() { }
        protected override Azure.ResourceManager.Purview.Models.PurviewAccountStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Purview.Models.PurviewAccountStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountPropertiesEndpoints : Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints>
    {
        internal AccountPropertiesEndpoints() { }
        protected override Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountPropertiesManagedResources : Azure.ResourceManager.Purview.Models.PurviewManagedResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources>
    {
        internal AccountPropertiesManagedResources() { }
        protected override Azure.ResourceManager.Purview.Models.PurviewManagedResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Purview.Models.PurviewManagedResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountSku>
    {
        public AccountSku() { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountSkuName? Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.AccountSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.AccountSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.AccountSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.AccountSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccountStatusErrorDetails : Azure.ResourceManager.Purview.Models.ErrorModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails>
    {
        internal AccountStatusErrorDetails() { }
        protected override Azure.ResourceManager.Purview.Models.ErrorModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Purview.Models.ErrorModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmPurviewModelFactory
    {
        public static Azure.ResourceManager.Purview.AccountData AccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus accountStatus = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, string createdByObjectId = null, string defaultDomain = null, Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints endpoints = null, string friendlyName = null, Azure.ResourceManager.Purview.Models.PurviewIngestionStorage ingestionStorage = null, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? managedEventHubState = default(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState?), string managedResourceGroupName = null, Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources managedResources = null, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? managedResourcesPublicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?), Azure.ResourceManager.Purview.Models.AccountMergeInfo mergeInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Purview.Models.PurviewProvisioningState? provisioningState = default(Azure.ResourceManager.Purview.Models.PurviewProvisioningState?), Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?), Azure.ResourceManager.Purview.Models.TenantEndpointState? tenantEndpointState = default(Azure.ResourceManager.Purview.Models.TenantEndpointState?), string cloudConnectorsAwsExternalId = null, Azure.ResourceManager.Purview.Models.Identity identity = null, Azure.ResourceManager.Purview.Models.AccountSku sku = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.AccountMergeInfo AccountMergeInfo(string accountLocation = null, string accountName = null, string accountResourceGroupName = null, string accountSubscriptionId = null, bool? deprovisioned = default(bool?), Azure.ResourceManager.Purview.Models.MergeStatus? mergeStatus = default(Azure.ResourceManager.Purview.Models.MergeStatus?), Azure.ResourceManager.Purview.Models.MergeAccountType? typeOfAccount = default(Azure.ResourceManager.Purview.Models.MergeAccountType?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.AccountPatch AccountPatch(Azure.ResourceManager.Purview.Models.Identity identity = null, Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus accountStatus = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, string createdByObjectId = null, string defaultDomain = null, Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints endpoints = null, string friendlyName = null, Azure.ResourceManager.Purview.Models.PurviewIngestionStorage ingestionStorage = null, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? managedEventHubState = default(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState?), string managedResourceGroupName = null, Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources managedResources = null, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? managedResourcesPublicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?), Azure.ResourceManager.Purview.Models.AccountMergeInfo mergeInfo = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Purview.Models.PurviewProvisioningState? provisioningState = default(Azure.ResourceManager.Purview.Models.PurviewProvisioningState?), Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?), Azure.ResourceManager.Purview.Models.TenantEndpointState? tenantEndpointState = default(Azure.ResourceManager.Purview.Models.TenantEndpointState?), string cloudConnectorsAwsExternalId = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.AccountPropertiesAccountStatus AccountPropertiesAccountStatus(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState? accountProvisioningState = default(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState?), Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.AccountPropertiesEndpoints AccountPropertiesEndpoints(string catalog = null, string scan = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.AccountPropertiesManagedResources AccountPropertiesManagedResources(string eventHubNamespace = null, string resourceGroup = null, string storageAccount = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails AccountStatusErrorDetails(string code = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.Models.ErrorModel> details = null, string message = null, string target = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.ErrorModel ErrorModel(string code = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.Models.ErrorModel> details = null, string message = null, string target = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.ErrorResponseModelError ErrorResponseModelError(string code = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.Models.ErrorModel> details = null, string message = null, string target = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.Identity Identity(string principalId = null, string tenantId = null, Azure.ResourceManager.Purview.Models.ManagedIdentityType? type = default(Azure.ResourceManager.Purview.Models.ManagedIdentityType?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Purview.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.ResourceManager.Purview.KafkaConfigurationData KafkaConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string consumerGroup = null, Azure.ResourceManager.Purview.Models.PurviewCredentials credentials = null, string eventHubPartitionId = null, Azure.Core.ResourceIdentifier eventHubResourceId = null, Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType? eventHubType = default(Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType?), Azure.ResourceManager.Purview.Models.PurviewEventStreamingState? eventStreamingState = default(Azure.ResourceManager.Purview.Models.PurviewEventStreamingState?), Azure.ResourceManager.Purview.Models.PurviewEventStreamingType? eventStreamingType = default(Azure.ResourceManager.Purview.Models.PurviewEventStreamingType?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult PrivateEndpointConnectionStatusUpdateResult(string privateEndpointId = null, string status = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey PurviewAccountAccessKey(string atlasKafkaPrimaryEndpoint = null, string atlasKafkaSecondaryEndpoint = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint PurviewAccountEndpoint(string catalog = null, string scan = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint PurviewAccountEndpoint(string catalog, string guardian, string scan) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult PurviewAccountNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason? reason = default(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountStatus PurviewAccountStatus(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState? accountProvisioningState = default(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState?), Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent PurviewBatchFeatureContent(System.Collections.Generic.IEnumerable<string> features = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus PurviewBatchFeatureStatus(System.Collections.Generic.IReadOnlyDictionary<string, bool> features = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewIngestionStorage PurviewIngestionStorage(string id = null, string primaryEndpoint = null, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewManagedResource PurviewManagedResource(string eventHubNamespace = null, string resourceGroup = null, string storageAccount = null) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData PurviewPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.ResourceIdentifier privateEndpointId, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState connectionState, string provisioningState) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData PurviewPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, string provisioningState = null, string privateEndpointId = null) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData PurviewPrivateLinkResourceData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties properties) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData PurviewPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties PurviewPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewQuotaName PurviewQuotaName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewUsage PurviewUsage(int? currentValue = default(int?), string id = null, int? limit = default(int?), Azure.ResourceManager.Purview.Models.PurviewUsageName name = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewUsageName PurviewUsageName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.UsageList UsageList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.Models.PurviewUsage> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.UserAssignedIdentity UserAssignedIdentity(string clientId = null, string principalId = null) { throw null; }
    }
    public partial class CollectionAdminUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>
    {
        public CollectionAdminUpdateContent() { }
        public string AdminObjectId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultPurviewAccountPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>
    {
        public DefaultPurviewAccountPayload() { }
        public string AccountName { get { throw null; } set { } }
        public string ResourceGroupName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public string ScopeTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountScopeType? ScopeType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.ErrorModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorModel>
    {
        internal ErrorModel() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.Models.ErrorModel> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.ErrorModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.ErrorModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.ErrorModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.ErrorModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.ErrorModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.ErrorModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorResponseModelError : Azure.ResourceManager.Purview.Models.ErrorModel, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.ErrorResponseModelError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorResponseModelError>
    {
        internal ErrorResponseModelError() { }
        protected override Azure.ResourceManager.Purview.Models.ErrorModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Purview.Models.ErrorModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.ErrorResponseModelError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.ErrorResponseModelError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.ErrorResponseModelError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.ErrorResponseModelError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorResponseModelError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorResponseModelError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.ErrorResponseModelError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Identity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.Identity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.Identity>
    {
        public Identity() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.ManagedIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Purview.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.Identity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.Identity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.Identity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.Identity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.Identity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.Identity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.Identity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.Identity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.Identity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedIdentityType : System.IEquatable<Azure.ResourceManager.Purview.Models.ManagedIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.ManagedIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ManagedIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ManagedIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.ManagedIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.ManagedIdentityType left, Azure.ResourceManager.Purview.Models.ManagedIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.ManagedIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.ManagedIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.ManagedIdentityType left, Azure.ResourceManager.Purview.Models.ManagedIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MergeAccountType : System.IEquatable<Azure.ResourceManager.Purview.Models.MergeAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MergeAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.MergeAccountType Primary { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.MergeAccountType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.MergeAccountType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.MergeAccountType left, Azure.ResourceManager.Purview.Models.MergeAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.MergeAccountType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.MergeAccountType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.MergeAccountType left, Azure.ResourceManager.Purview.Models.MergeAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MergeStatus : System.IEquatable<Azure.ResourceManager.Purview.Models.MergeStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MergeStatus(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.MergeStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.MergeStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.MergeStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.MergeStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.MergeStatus left, Azure.ResourceManager.Purview.Models.MergeStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.MergeStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.MergeStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.MergeStatus left, Azure.ResourceManager.Purview.Models.MergeStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionStatusUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>
    {
        public PrivateEndpointConnectionStatusUpdateContent() { }
        public string PrivateEndpointId { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionStatusUpdateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>
    {
        internal PrivateEndpointConnectionStatusUpdateResult() { }
        public string PrivateEndpointId { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewAccountAccessKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>
    {
        internal PurviewAccountAccessKey() { }
        public string AtlasKafkaPrimaryEndpoint { get { throw null; } }
        public string AtlasKafkaSecondaryEndpoint { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewAccountEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint>
    {
        internal PurviewAccountEndpoint() { }
        public string Catalog { get { throw null; } }
        public string Guardian { get { throw null; } }
        public string Scan { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewAccountNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent>
    {
        public PurviewAccountNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewAccountNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>
    {
        internal PurviewAccountNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason? Reason { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewAccountNameUnavailableReason : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewAccountNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason left, Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason left, Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewAccountProvisioningState : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewAccountProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState SoftDeleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewAccountScopeType : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewAccountScopeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewAccountScopeType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountScopeType Subscription { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountScopeType Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType left, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountScopeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountScopeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType left, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewAccountSkuName : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewAccountSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewAccountSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountSkuName Free { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountSkuName Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName left, Azure.ResourceManager.Purview.Models.PurviewAccountSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName left, Azure.ResourceManager.Purview.Models.PurviewAccountSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewAccountStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>
    {
        internal PurviewAccountStatus() { }
        public Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState? AccountProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.AccountStatusErrorDetails ErrorDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewAccountStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewAccountStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewBatchFeatureContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent>
    {
        public PurviewBatchFeatureContent() { }
        public System.Collections.Generic.IList<string> Features { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewBatchFeatureStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>
    {
        internal PurviewBatchFeatureStatus() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, bool> Features { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>
    {
        public PurviewCredentials() { }
        public string IdentityId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewCredentialsType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewCredentialsType : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewCredentialsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewCredentialsType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewCredentialsType None { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewCredentialsType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewCredentialsType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewCredentialsType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewCredentialsType left, Azure.ResourceManager.Purview.Models.PurviewCredentialsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewCredentialsType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewCredentialsType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewCredentialsType left, Azure.ResourceManager.Purview.Models.PurviewCredentialsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewEventStreamingState : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewEventStreamingState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewEventStreamingState(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewEventStreamingState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewEventStreamingState Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewEventStreamingState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewEventStreamingState left, Azure.ResourceManager.Purview.Models.PurviewEventStreamingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewEventStreamingState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewEventStreamingState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewEventStreamingState left, Azure.ResourceManager.Purview.Models.PurviewEventStreamingState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewEventStreamingType : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewEventStreamingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewEventStreamingType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewEventStreamingType Azure { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewEventStreamingType Managed { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewEventStreamingType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewEventStreamingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewEventStreamingType left, Azure.ResourceManager.Purview.Models.PurviewEventStreamingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewEventStreamingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewEventStreamingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewEventStreamingType left, Azure.ResourceManager.Purview.Models.PurviewEventStreamingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewIngestionStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>
    {
        public PurviewIngestionStorage() { }
        public string Id { get { throw null; } }
        public string PrimaryEndpoint { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewIngestionStorage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewIngestionStorage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewIngestionStorage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewIngestionStorage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewKafkaEventHubType : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewKafkaEventHubType(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType Hook { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType Notification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType left, Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType left, Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewManagedEventHubState : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewManagedEventHubState(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState left, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState left, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewManagedResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>
    {
        internal PurviewManagedResource() { }
        public string EventHubNamespace { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string StorageAccount { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewManagedResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewManagedResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewManagedResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewManagedResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties>
    {
        internal PurviewPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState>
    {
        public PurviewPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewPrivateLinkServiceStatus : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewPrivateLinkServiceStatus(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Rejected { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus left, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus left, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewProvisioningState : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Moving { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState SoftDeleted { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState SoftDeleting { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewProvisioningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PurviewPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PurviewPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewQuotaName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>
    {
        internal PurviewQuotaName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewQuotaName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewQuotaName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewQuotaName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewQuotaName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsage>
    {
        internal PurviewUsage() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.PurviewUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewUsageName : Azure.ResourceManager.Purview.Models.PurviewQuotaName, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>
    {
        internal PurviewUsageName() { }
        protected override Azure.ResourceManager.Purview.Models.PurviewQuotaName JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Purview.Models.PurviewQuotaName PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.PurviewUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TenantEndpointState : System.IEquatable<Azure.ResourceManager.Purview.Models.TenantEndpointState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TenantEndpointState(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.TenantEndpointState Disabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.TenantEndpointState Enabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.TenantEndpointState NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.TenantEndpointState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.TenantEndpointState left, Azure.ResourceManager.Purview.Models.TenantEndpointState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.TenantEndpointState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.TenantEndpointState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.TenantEndpointState left, Azure.ResourceManager.Purview.Models.TenantEndpointState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UsageList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.UsageList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UsageList>
    {
        internal UsageList() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Purview.Models.PurviewUsage> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.UsageList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.UsageList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.UsageList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.UsageList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.UsageList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.UsageList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UsageList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UsageList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UsageList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.UserAssignedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UserAssignedIdentity>
    {
        public UserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.Purview.Models.UserAssignedIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Purview.Models.UserAssignedIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Purview.Models.UserAssignedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.UserAssignedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.UserAssignedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.UserAssignedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UserAssignedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UserAssignedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.UserAssignedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
