namespace Azure.ResourceManager.Purview
{
    public partial class PurviewAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>, System.Collections.IEnumerable
    {
        protected PurviewAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.PurviewAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Purview.PurviewAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PurviewAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PurviewAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PurviewAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewAccountData>
    {
        public PurviewAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Purview.Models.PurviewAccountStatus AccountStatus { get { throw null; } }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewIngestionStorage IngestionStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? ManagedEventHubState { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedResource ManagedResources { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess? ManagedResourcesPublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountSku Sku { get { throw null; } }
        Azure.ResourceManager.Purview.PurviewAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.PurviewAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PurviewAccountResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus> AccountGetFeature(Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>> AccountGetFeatureAsync(Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddRootCollectionAdmin(Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddRootCollectionAdminAsync(Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetIngestionPrivateEndpointConnections(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetIngestionPrivateEndpointConnectionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> GetPurviewKafkaConfiguration(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>> GetPurviewKafkaConfigurationAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewKafkaConfigurationCollection GetPurviewKafkaConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetPurviewPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetPurviewPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionCollection GetPurviewPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetPurviewPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetPurviewPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateLinkResourceCollection GetPurviewPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.PurviewAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.Models.PurviewAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult> UpdateStatusIngestionPrivateEndpointConnection(Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult>> UpdateStatusIngestionPrivateEndpointConnectionAsync(Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PurviewExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult> CheckPurviewAccountNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>> CheckPurviewAccountNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> GetDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> GetDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> GetPurviewAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewAccountResource GetPurviewAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewAccountCollection GetPurviewAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource GetPurviewKafkaConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource GetPurviewPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateLinkResource GetPurviewPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Purview.Models.PurviewUsage> GetUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Purview.Models.PurviewUsage> GetUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response RemoveDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RemoveDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> SetDefaultAccount(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> SetDefaultAccountAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus> SubscriptionGetFeature(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>> SubscriptionGetFeatureAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewKafkaConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>, System.Collections.IEnumerable
    {
        protected PurviewKafkaConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string kafkaConfigurationName, Azure.ResourceManager.Purview.PurviewKafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string kafkaConfigurationName, Azure.ResourceManager.Purview.PurviewKafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> Get(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>> GetAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> GetIfExists(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>> GetIfExistsAsync(string kafkaConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PurviewKafkaConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewKafkaConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewKafkaConfigurationData>
    {
        public PurviewKafkaConfigurationData() { }
        public string ConsumerGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewCredentials Credentials { get { throw null; } set { } }
        public string EventHubPartitionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EventHubResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType? EventHubType { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewEventStreamingState? EventStreamingState { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewEventStreamingType? EventStreamingType { get { throw null; } set { } }
        Azure.ResourceManager.Purview.PurviewKafkaConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewKafkaConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewKafkaConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.PurviewKafkaConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewKafkaConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewKafkaConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewKafkaConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewKafkaConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PurviewKafkaConfigurationResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewKafkaConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string kafkaConfigurationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewKafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewKafkaConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PurviewPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PurviewPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>
    {
        public PurviewPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PurviewPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewPrivateLinkResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PurviewPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PurviewPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PurviewPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Purview.PurviewPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PurviewPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData>
    {
        internal PurviewPrivateLinkResourceData() { }
        public Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties Properties { get { throw null; } }
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
        public virtual Azure.ResourceManager.Purview.PurviewAccountResource GetPurviewAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewKafkaConfigurationResource GetPurviewKafkaConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionResource GetPurviewPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewPrivateLinkResource GetPurviewPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePurviewResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePurviewResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.PurviewAccountResource>> GetPurviewAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Purview.PurviewAccountCollection GetPurviewAccounts() { throw null; }
    }
    public partial class MockablePurviewSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePurviewSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult> CheckPurviewAccountNameAvailability(Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult>> CheckPurviewAccountNameAvailabilityAsync(Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccounts(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.PurviewAccountResource> GetPurviewAccountsAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Purview.Models.PurviewUsage> GetUsages(Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Purview.Models.PurviewUsage> GetUsagesAsync(Azure.Core.AzureLocation location, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus> SubscriptionGetFeature(string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>> SubscriptionGetFeatureAsync(string locations, Azure.ResourceManager.Purview.Models.PurviewBatchFeatureContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockablePurviewTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePurviewTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> GetDefaultAccount(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> GetDefaultAccountAsync(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveDefaultAccount(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveDefaultAccountAsync(System.Guid scopeTenantId, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType scopeType, string scope = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload> SetDefaultAccount(Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>> SetDefaultAccountAsync(Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload defaultAccountPayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Purview.Models
{
    public static partial class ArmPurviewModelFactory
    {
        public static Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateResult PrivateEndpointConnectionStatusUpdateResult(string privateEndpointId = null, string status = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountAccessKey PurviewAccountAccessKey(string atlasKafkaPrimaryEndpoint = null, string atlasKafkaSecondaryEndpoint = null) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewAccountData PurviewAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Purview.Models.PurviewAccountSku sku = null, Azure.ResourceManager.Purview.Models.PurviewAccountStatus accountStatus = null, string cloudConnectorsAwsExternalId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, string createdByObjectId = null, Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint endpoints = null, string friendlyName = null, Azure.ResourceManager.Purview.Models.PurviewIngestionStorage ingestionStorage = null, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? managedEventHubState = default(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState?), string managedResourceGroupName = null, Azure.ResourceManager.Purview.Models.PurviewManagedResource managedResources = null, Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess? managedResourcesPublicNetworkAccess = default(Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Purview.Models.PurviewProvisioningState? provisioningState = default(Azure.ResourceManager.Purview.Models.PurviewProvisioningState?), Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.Purview.PurviewAccountData PurviewAccountData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Purview.Models.PurviewAccountSku sku, string cloudConnectorsAwsExternalId, System.DateTimeOffset? createdOn, string createdBy, string createdByObjectId, Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint endpoints, string friendlyName, string managedResourceGroupName, Azure.ResourceManager.Purview.Models.PurviewManagedResource managedResources, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> privateEndpointConnections, Azure.ResourceManager.Purview.Models.PurviewProvisioningState? provisioningState, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? publicNetworkAccess, Azure.ResourceManager.Models.ManagedServiceIdentity identity) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint PurviewAccountEndpoint(string catalog = null, string guardian = null, string scan = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountNameAvailabilityResult PurviewAccountNameAvailabilityResult(string message = null, bool? isNameAvailable = default(bool?), Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason? reason = default(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountProperties PurviewAccountProperties(Azure.ResourceManager.Purview.Models.PurviewAccountStatus accountStatus = null, string cloudConnectorsAwsExternalId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, string createdByObjectId = null, Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint endpoints = null, string friendlyName = null, Azure.ResourceManager.Purview.Models.PurviewIngestionStorage ingestionStorage = null, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? managedEventHubState = default(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState?), string managedResourceGroupName = null, Azure.ResourceManager.Purview.Models.PurviewManagedResource managedResources = null, Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess? managedResourcesPublicNetworkAccess = default(Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Purview.Models.PurviewProvisioningState? provisioningState = default(Azure.ResourceManager.Purview.Models.PurviewProvisioningState?), Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountSku PurviewAccountSku(int? capacity = default(int?), Azure.ResourceManager.Purview.Models.PurviewAccountSkuName? name = default(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewAccountStatus PurviewAccountStatus(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState? accountProvisioningState = default(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus PurviewBatchFeatureStatus(System.Collections.Generic.IReadOnlyDictionary<string, bool> features = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewIngestionStorage PurviewIngestionStorage(string id = null, string primaryEndpoint = null, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewKafkaConfigurationData PurviewKafkaConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string consumerGroup = null, Azure.ResourceManager.Purview.Models.PurviewCredentials credentials = null, string eventHubPartitionId = null, Azure.Core.ResourceIdentifier eventHubResourceId = null, Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType? eventHubType = default(Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType?), Azure.ResourceManager.Purview.Models.PurviewEventStreamingState? eventStreamingState = default(Azure.ResourceManager.Purview.Models.PurviewEventStreamingState?), Azure.ResourceManager.Purview.Models.PurviewEventStreamingType? eventStreamingType = default(Azure.ResourceManager.Purview.Models.PurviewEventStreamingType?)) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewManagedResource PurviewManagedResource(Azure.Core.ResourceIdentifier eventHubNamespace = null, Azure.Core.ResourceIdentifier resourceGroup = null, Azure.Core.ResourceIdentifier storageAccount = null) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData PurviewPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceConnectionState connectionState = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.Purview.PurviewPrivateLinkResourceData PurviewPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewPrivateLinkResourceProperties PurviewPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewQuotaName PurviewQuotaName(string localizedValue = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewUsage PurviewUsage(int? currentValue = default(int?), string id = null, int? limit = default(int?), Azure.ResourceManager.Purview.Models.PurviewUsageName name = null, string unit = null) { throw null; }
        public static Azure.ResourceManager.Purview.Models.PurviewUsageName PurviewUsageName(string localizedValue = null, string value = null) { throw null; }
    }
    public partial class CollectionAdminUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.CollectionAdminUpdateContent>
    {
        public CollectionAdminUpdateContent() { }
        public string AdminObjectId { get { throw null; } set { } }
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
        public System.Guid? ScopeTenantId { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountScopeType? ScopeType { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.DefaultPurviewAccountPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedResourcesPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedResourcesPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess Enabled { get { throw null; } }
        public static Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionStatusUpdateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PrivateEndpointConnectionStatusUpdateContent>
    {
        public PrivateEndpointConnectionStatusUpdateContent() { }
        public string PrivateEndpointId { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string Guardian { get { throw null; } }
        public string Scan { get { throw null; } }
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
        public string ResourceType { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason left, Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason left, Azure.ResourceManager.Purview.Models.PurviewAccountNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountPatch>
    {
        public PurviewAccountPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Purview.Models.PurviewAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountProperties>
    {
        public PurviewAccountProperties() { }
        public Azure.ResourceManager.Purview.Models.PurviewAccountStatus AccountStatus { get { throw null; } }
        public string CloudConnectorsAwsExternalId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByObjectId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountEndpoint Endpoints { get { throw null; } }
        public string FriendlyName { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewIngestionStorage IngestionStorage { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState? ManagedEventHubState { get { throw null; } set { } }
        public string ManagedResourceGroupName { get { throw null; } set { } }
        public Azure.ResourceManager.Purview.Models.PurviewManagedResource ManagedResources { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.ManagedResourcesPublicNetworkAccess? ManagedResourcesPublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Purview.PurviewPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        Azure.ResourceManager.Purview.Models.PurviewAccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType left, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountScopeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountScopeType left, Azure.ResourceManager.Purview.Models.PurviewAccountScopeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewAccountSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountSku>
    {
        internal PurviewAccountSku() { }
        public int? Capacity { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewAccountSkuName? Name { get { throw null; } }
        Azure.ResourceManager.Purview.Models.PurviewAccountSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewAccountSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName left, Azure.ResourceManager.Purview.Models.PurviewAccountSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewAccountSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewAccountSkuName left, Azure.ResourceManager.Purview.Models.PurviewAccountSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewAccountStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewAccountStatus>
    {
        internal PurviewAccountStatus() { }
        public Azure.ResourceManager.Purview.Models.PurviewAccountProvisioningState? AccountProvisioningState { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
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
        Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewBatchFeatureStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewCredentials>
    {
        public PurviewCredentials() { }
        public Azure.ResourceManager.Purview.Models.PurviewCredentialsType? CredentialsType { get { throw null; } set { } }
        public string IdentityId { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewCredentialsType left, Azure.ResourceManager.Purview.Models.PurviewCredentialsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewCredentialsType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewEventStreamingState left, Azure.ResourceManager.Purview.Models.PurviewEventStreamingState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewEventStreamingState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewEventStreamingType left, Azure.ResourceManager.Purview.Models.PurviewEventStreamingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewEventStreamingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewEventStreamingType left, Azure.ResourceManager.Purview.Models.PurviewEventStreamingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewIngestionStorage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewIngestionStorage>
    {
        public PurviewIngestionStorage() { }
        public string Id { get { throw null; } }
        public string PrimaryEndpoint { get { throw null; } }
        public Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType left, Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewKafkaEventHubType (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState left, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState left, Azure.ResourceManager.Purview.Models.PurviewManagedEventHubState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewManagedResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewManagedResource>
    {
        internal PurviewManagedResource() { }
        public Azure.Core.ResourceIdentifier EventHubNamespace { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccount { get { throw null; } }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus left, Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPrivateLinkServiceStatus (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewProvisioningState left, Azure.ResourceManager.Purview.Models.PurviewProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewProvisioningState (string value) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess left, Azure.ResourceManager.Purview.Models.PurviewPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PurviewQuotaName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewQuotaName>
    {
        internal PurviewQuotaName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
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
        Azure.ResourceManager.Purview.Models.PurviewUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PurviewUsageName : Azure.ResourceManager.Purview.Models.PurviewQuotaName, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>
    {
        internal PurviewUsageName() { }
        Azure.ResourceManager.Purview.Models.PurviewUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Purview.Models.PurviewUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Purview.Models.PurviewUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
