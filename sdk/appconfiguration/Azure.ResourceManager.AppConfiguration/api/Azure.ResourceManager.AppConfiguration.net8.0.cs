namespace Azure.ResourceManager.AppConfiguration
{
    public static partial class AppConfigurationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult> CheckAppConfigurationNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>> CheckAppConfigurationNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource GetAppConfigurationKeyValueResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource GetAppConfigurationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource GetAppConfigurationPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource GetAppConfigurationReplicaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource GetAppConfigurationSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStore(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetAppConfigurationStoreAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource GetAppConfigurationStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationStoreCollection GetAppConfigurationStores(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStoresAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetDeletedAppConfigurationStore(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetDeletedAppConfigurationStoreAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource GetDeletedAppConfigurationStoreResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreCollection GetDeletedAppConfigurationStores(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
    }
    public partial class AppConfigurationKeyValueCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationKeyValueCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string keyValueName, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string keyValueName, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> Get(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as it never works, it will be removed in a future release", false)]
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete as it never works, it will be removed in a future release", false)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> GetAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> GetIfExists(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> GetIfExistsAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as it never works, it will be removed in a future release", false)]
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as it never works, it will be removed in a future release", false)]
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>.GetEnumerator() { throw null; }
        [System.ObsoleteAttribute("This method is obsolete as it never works, it will be removed in a future release", false)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationKeyValueData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>
    {
        public AppConfigurationKeyValueData() { }
        public string ContentType { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsLocked { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationKeyValueResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationKeyValueResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string keyValueName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppConfigurationPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>
    {
        public AppConfigurationPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppConfigurationPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationPrivateLinkResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string groupName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> Get(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetIfExists(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetIfExistsAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>
    {
        internal AppConfigurationPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationReplicaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationReplicaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicaName, Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> Get(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>> GetAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> GetIfExists(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>> GetIfExistsAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationReplicaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>
    {
        public AppConfigurationReplicaData() { }
        public string Endpoint { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationReplicaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationReplicaResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string replicaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppConfigurationSnapshotCollection : Azure.ResourceManager.ArmCollection
    {
        protected AppConfigurationSnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppConfigurationSnapshotData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>
    {
        public AppConfigurationSnapshotData() { }
        public Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType? CompositionType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter> Filters { get { throw null; } }
        public long? ItemsCount { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public long? RetentionPeriod { get { throw null; } set { } }
        public long? Size { get { throw null; } }
        public string SnapshotType { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus? Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationSnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationSnapshotResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName, string snapshotName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>, System.Collections.IEnumerable
    {
        protected AppConfigurationStoreCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configStoreName, Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configStoreName, Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> Get(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAll(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAllAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetIfExists(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetIfExistsAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppConfigurationStoreData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>
    {
        public AppConfigurationStoreData(Azure.Core.AzureLocation location, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku sku) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationCreateMode? CreateMode { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties DataPlaneProxy { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties EncryptionKeyVaultProperties { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationStoreResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppConfigurationStoreResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configStoreName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource> GetAppConfigurationKeyValue(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource>> GetAppConfigurationKeyValueAsync(string keyValueName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueCollection GetAppConfigurationKeyValues() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource> GetAppConfigurationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource>> GetAppConfigurationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionCollection GetAppConfigurationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource> GetAppConfigurationPrivateLinkResource(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource>> GetAppConfigurationPrivateLinkResourceAsync(string groupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceCollection GetAppConfigurationPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource> GetAppConfigurationReplica(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource>> GetAppConfigurationReplicaAsync(string replicaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaCollection GetAppConfigurationReplicas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource> GetAppConfigurationSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource>> GetAppConfigurationSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotCollection GetAppConfigurationSnapshots() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey> GetKeys(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey> GetKeysAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey> RegenerateKey(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>> RegenerateKeyAsync(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAppConfigurationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAppConfigurationContext() { }
        public static Azure.ResourceManager.AppConfiguration.AzureResourceManagerAppConfigurationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeletedAppConfigurationStoreCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>, System.Collections.IEnumerable
    {
        protected DeletedAppConfigurationStoreCollection() { }
        public virtual Azure.Response<bool> Exists(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> Get(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetAsync(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetIfExists(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetIfExistsAsync(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeletedAppConfigurationStoreData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>
    {
        internal DeletedAppConfigurationStoreData() { }
        public Azure.Core.ResourceIdentifier ConfigurationStoreId { get { throw null; } }
        public System.DateTimeOffset? DeletedOn { get { throw null; } }
        public bool? IsPurgeProtectionEnabled { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedAppConfigurationStoreResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedAppConfigurationStoreResource() { }
        public virtual Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location, string configStoreName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PurgeDeleted(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PurgeDeletedAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.AppConfiguration.Mocking
{
    public partial class MockableAppConfigurationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAppConfigurationArmClient() { }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueResource GetAppConfigurationKeyValueResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionResource GetAppConfigurationPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResource GetAppConfigurationPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaResource GetAppConfigurationReplicaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotResource GetAppConfigurationSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource GetAppConfigurationStoreResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource GetDeletedAppConfigurationStoreResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAppConfigurationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAppConfigurationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStore(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource>> GetAppConfigurationStoreAsync(string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.AppConfigurationStoreCollection GetAppConfigurationStores() { throw null; }
    }
    public partial class MockableAppConfigurationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAppConfigurationSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult> CheckAppConfigurationNameAvailability(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>> CheckAppConfigurationNameAvailabilityAsync(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStores(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppConfiguration.AppConfigurationStoreResource> GetAppConfigurationStoresAsync(string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource> GetDeletedAppConfigurationStore(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreResource>> GetDeletedAppConfigurationStoreAsync(Azure.Core.AzureLocation location, string configStoreName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreCollection GetDeletedAppConfigurationStores() { throw null; }
    }
}
namespace Azure.ResourceManager.AppConfiguration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationActionsRequired : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationActionsRequired(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired None { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired Recreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum AppConfigurationCreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class AppConfigurationDataPlaneProxyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties>
    {
        public AppConfigurationDataPlaneProxyProperties() { }
        public Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation? PrivateLinkDelegation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties>
    {
        public AppConfigurationKeyVaultProperties() { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyIdentifier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent>
    {
        public AppConfigurationNameAvailabilityContent(string name, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType resourceType) { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>
    {
        internal AppConfigurationNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationPrivateEndpointConnectionReference : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference>
    {
        internal AppConfigurationPrivateEndpointConnectionReference() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState ConnectionState { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState>
    {
        public AppConfigurationPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired? ActionsRequired { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationProvisioningState : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppConfigurationRegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent>
    {
        public AppConfigurationRegenerateKeyContent() { }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationRegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationReplicaProvisioningState : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationReplicaProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationResourceType : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationResourceType(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType MicrosoftAppConfigurationConfigurationStores { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppConfigurationSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku>
    {
        public AppConfigurationSku(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppConfigurationSnapshotStatus : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppConfigurationSnapshotStatus(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus Archived { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus Provisioning { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus Ready { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus left, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppConfigurationStoreApiKey : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>
    {
        internal AppConfigurationStoreApiKey() { }
        public string ConnectionString { get { throw null; } }
        public string Id { get { throw null; } }
        public bool? IsReadOnly { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppConfigurationStorePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch>
    {
        public AppConfigurationStorePatch() { }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties DataPlaneProxy { get { throw null; } set { } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties EncryptionKeyVaultProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStorePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAppConfigurationModelFactory
    {
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationKeyValueData AppConfigurationKeyValueData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string key = null, string label = null, string value = null, string contentType = null, Azure.ETag? eTag = default(Azure.ETag?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), bool? isLocked = default(bool?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationNameAvailabilityResult AppConfigurationNameAvailabilityResult(bool? isNameAvailable = default(bool?), string message = null, string reason = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateEndpointConnectionData AppConfigurationPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference AppConfigurationPrivateEndpointConnectionReference(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState connectionState = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationPrivateLinkResourceData AppConfigurationPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionState AppConfigurationPrivateLinkServiceConnectionState(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus? status = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateLinkServiceConnectionStatus?), string description = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired? actionsRequired = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationActionsRequired?)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationReplicaData AppConfigurationReplicaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string endpoint = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationReplicaProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationSnapshotData AppConfigurationSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string snapshotType = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState?), Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus? status = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationSnapshotStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter> filters = null, Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType? compositionType = default(Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), long? retentionPeriod = default(long?), long? size = default(long?), long? itemsCount = default(long?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.AppConfigurationStoreApiKey AppConfigurationStoreApiKey(string id = null, string name = null, string value = null, string connectionString = null, System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), bool? isReadOnly = default(bool?)) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData AppConfigurationStoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string skuName = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string endpoint = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties encryptionKeyVaultProperties = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference> privateEndpointConnections = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess?), bool? disableLocalAuth = default(bool?), int? softDeleteRetentionInDays = default(int?), bool? enablePurgeProtection = default(bool?), Azure.ResourceManager.AppConfiguration.Models.AppConfigurationDataPlaneProxyProperties dataPlaneProxy = null, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationCreateMode? createMode = default(Azure.ResourceManager.AppConfiguration.Models.AppConfigurationCreateMode?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.AppConfiguration.AppConfigurationStoreData AppConfigurationStoreData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string skuName, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationProvisioningState? provisioningState, System.DateTimeOffset? createdOn, string endpoint, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationKeyVaultProperties encryptionKeyVaultProperties, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPrivateEndpointConnectionReference> privateEndpointConnections, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationPublicNetworkAccess? publicNetworkAccess, bool? disableLocalAuth, int? softDeleteRetentionInDays, bool? enablePurgeProtection, Azure.ResourceManager.AppConfiguration.Models.AppConfigurationCreateMode? createMode) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.DeletedAppConfigurationStoreData DeletedAppConfigurationStoreData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier configurationStoreId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.DateTimeOffset? deletedOn = default(System.DateTimeOffset?), System.DateTimeOffset? scheduledPurgeOn = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> tags = null, bool? isPurgeProtectionEnabled = default(bool?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataPlaneProxyAuthenticationMode : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataPlaneProxyAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode Local { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode PassThrough { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode left, Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode left, Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataPlaneProxyPrivateLinkDelegation : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataPlaneProxyPrivateLinkDelegation(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation Disabled { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation left, Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation left, Azure.ResourceManager.AppConfiguration.Models.DataPlaneProxyPrivateLinkDelegation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotCompositionType : System.IEquatable<Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotCompositionType(string value) { throw null; }
        public static Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType Key { get { throw null; } }
        public static Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType KeyLabel { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType left, Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType left, Azure.ResourceManager.AppConfiguration.Models.SnapshotCompositionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotKeyValueFilter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter>
    {
        public SnapshotKeyValueFilter(string key) { }
        public string Key { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppConfiguration.Models.SnapshotKeyValueFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
