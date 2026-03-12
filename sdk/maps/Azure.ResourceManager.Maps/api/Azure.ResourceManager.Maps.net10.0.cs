namespace Azure.ResourceManager.Maps
{
    public partial class AzureResourceManagerMapsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMapsContext() { }
        public static Azure.ResourceManager.Maps.AzureResourceManagerMapsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MapsAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>, System.Collections.IEnumerable
    {
        protected MapsAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.MapsAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Maps.MapsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.MapsAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.Maps.MapsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maps.MapsAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maps.MapsAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Maps.MapsAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Maps.MapsAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maps.MapsAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maps.MapsAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MapsAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>
    {
        public MapsAccountData(Azure.Core.AzureLocation location, Azure.ResourceManager.Maps.Models.MapsSku sku) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsAccountKind? Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsAccountProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.MapsAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MapsAccountResource() { }
        public virtual Azure.ResourceManager.Maps.MapsAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource> GetMapsCreator(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource>> GetMapsCreatorAsync(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maps.MapsCreatorCollection GetMapsCreators() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maps.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.PrivateLinkResource> GetPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.PrivateLinkResource>> GetPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maps.PrivateLinkResourceCollection GetPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountSasToken> GetSas(Azure.ResourceManager.Maps.Models.MapsAccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>> GetSasAsync(Azure.ResourceManager.Maps.Models.MapsAccountSasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys> RegenerateKeys(Azure.ResourceManager.Maps.Models.MapsKeySpecification keySpecification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.Models.MapsAccountKeys>> RegenerateKeysAsync(Azure.ResourceManager.Maps.Models.MapsKeySpecification keySpecification, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Maps.MapsAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> Update(Azure.ResourceManager.Maps.Models.MapsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> UpdateAsync(Azure.ResourceManager.Maps.Models.MapsAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MapsCreatorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.MapsCreatorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsCreatorResource>, System.Collections.IEnumerable
    {
        protected MapsCreatorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.MapsCreatorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string creatorName, Azure.ResourceManager.Maps.MapsCreatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.MapsCreatorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string creatorName, Azure.ResourceManager.Maps.MapsCreatorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource> Get(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maps.MapsCreatorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maps.MapsCreatorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource>> GetAsync(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Maps.MapsCreatorResource> GetIfExists(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Maps.MapsCreatorResource>> GetIfExistsAsync(string creatorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maps.MapsCreatorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.MapsCreatorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maps.MapsCreatorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsCreatorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MapsCreatorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsCreatorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>
    {
        public MapsCreatorData(Azure.Core.AzureLocation location, Azure.ResourceManager.Maps.Models.MapsCreatorProperties properties) { }
        public Azure.ResourceManager.Maps.Models.MapsCreatorProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.MapsCreatorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsCreatorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsCreatorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsCreatorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsCreatorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsCreatorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MapsCreatorResource() { }
        public virtual Azure.ResourceManager.Maps.MapsCreatorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string creatorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Maps.MapsCreatorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsCreatorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsCreatorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsCreatorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsCreatorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource> Update(Azure.ResourceManager.Maps.Models.MapsCreatorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsCreatorResource>> UpdateAsync(Azure.ResourceManager.Maps.Models.MapsCreatorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MapsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> GetMapsAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maps.MapsAccountResource GetMapsAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maps.MapsAccountCollection GetMapsAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Maps.MapsCreatorResource GetMapsCreatorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maps.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Maps.PrivateLinkResource GetPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MapsPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>
    {
        public MapsPrivateEndpointConnectionData() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>
    {
        internal MapsPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.MapsPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Maps.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLinkResource() { }
        public virtual Azure.ResourceManager.Maps.MapsPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.PrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.PrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Maps.MapsPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.MapsPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.MapsPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.PrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.PrivateLinkResource>, System.Collections.IEnumerable
    {
        protected PrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Maps.PrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Maps.PrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maps.PrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.PrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Maps.PrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Maps.PrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Maps.PrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Maps.PrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Maps.PrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.PrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
}
namespace Azure.ResourceManager.Maps.Mocking
{
    public partial class MockableMapsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMapsArmClient() { }
        public virtual Azure.ResourceManager.Maps.MapsAccountResource GetMapsAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Maps.MapsCreatorResource GetMapsCreatorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Maps.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Maps.PrivateLinkResource GetPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMapsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMapsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Maps.MapsAccountResource>> GetMapsAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Maps.MapsAccountCollection GetMapsAccounts() { throw null; }
    }
    public partial class MockableMapsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMapsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Maps.MapsAccountResource> GetMapsAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Maps.Models
{
    public static partial class ArmMapsModelFactory
    {
        public static Azure.ResourceManager.Maps.MapsAccountData MapsAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Maps.Models.MapsSku sku = null, Azure.ResourceManager.Maps.Models.MapsAccountKind? kind = default(Azure.ResourceManager.Maps.Models.MapsAccountKind?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Maps.Models.MapsAccountProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountKeys MapsAccountKeys(System.DateTimeOffset? primaryKeyLastUpdatedOn = default(System.DateTimeOffset?), string primaryKey = null, string secondaryKey = null, System.DateTimeOffset? secondaryKeyLastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountPatch MapsAccountPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Maps.Models.MapsAccountKind? kind = default(Azure.ResourceManager.Maps.Models.MapsAccountKind?), Azure.ResourceManager.Maps.Models.MapsSku sku = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Guid? uniqueId = default(System.Guid?), bool? disableLocalAuth = default(bool?), string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsLinkedResource> linkedResources = null, Azure.ResourceManager.Maps.Models.MapsEncryption encryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.LocationsItem> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Maps.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Maps.Models.PublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsCorsRule> corsRules = null) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountPatch MapsAccountPatch(System.Collections.Generic.IDictionary<string, string> tags, Azure.ResourceManager.Maps.Models.MapsAccountKind? kind, Azure.ResourceManager.Maps.Models.MapsSku sku, Azure.ResourceManager.Models.ManagedServiceIdentity identity, System.Guid? uniqueId, bool? disableLocalAuth, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsLinkedResource> linkedResources, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsCorsRule> corsRulesValue, Azure.ResourceManager.Maps.Models.MapsEncryption encryption) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountProperties MapsAccountProperties(System.Guid? uniqueId, bool? disableLocalAuth, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsLinkedResource> linkedResources, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsCorsRule> corsRulesValue, Azure.ResourceManager.Maps.Models.MapsEncryption encryption) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountProperties MapsAccountProperties(System.Guid? uniqueId = default(System.Guid?), bool? disableLocalAuth = default(bool?), string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsLinkedResource> linkedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.MapsCorsRule> corsRules = null, Azure.ResourceManager.Maps.Models.MapsEncryption encryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.Models.LocationsItem> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Maps.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Maps.Models.PublicNetworkAccess?)) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountSasContent MapsAccountSasContent(Azure.ResourceManager.Maps.Models.MapsSigningKey signingKey = default(Azure.ResourceManager.Maps.Models.MapsSigningKey), string principalId = null, System.Collections.Generic.IEnumerable<string> regions = null, int maxRatePerSecond = 0, string start = null, string expiry = null) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountSasToken MapsAccountSasToken(string accountSasToken = null) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsCorsRule MapsCorsRule(System.Collections.Generic.IEnumerable<string> allowedOrigins = null) { throw null; }
        public static Azure.ResourceManager.Maps.MapsCreatorData MapsCreatorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Maps.Models.MapsCreatorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsCreatorPatch MapsCreatorPatch(System.Collections.Generic.IDictionary<string, string> tags, string provisioningState, int? storageUnits) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsCreatorPatch MapsCreatorPatch(System.Collections.Generic.IDictionary<string, string> tags = null, string provisioningState = null, int? storageUnits = default(int?), int? totalStorageUnitSizeInBytes = default(int?), int? consumedStorageUnitSizeInBytes = default(int?)) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsCreatorProperties MapsCreatorProperties(string provisioningState, int storageUnits) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsCreatorProperties MapsCreatorProperties(string provisioningState = null, int storageUnits = 0, int? totalStorageUnitSizeInBytes = default(int?), int? consumedStorageUnitSizeInBytes = default(int?)) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsKeySpecification MapsKeySpecification(Azure.ResourceManager.Maps.Models.MapsKeyType keyType = default(Azure.ResourceManager.Maps.Models.MapsKeyType)) { throw null; }
        public static Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData MapsPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null) { throw null; }
        public static Azure.ResourceManager.Maps.MapsPrivateLinkResourceData MapsPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsSku MapsSku(Azure.ResourceManager.Maps.Models.MapsSkuName name = default(Azure.ResourceManager.Maps.Models.MapsSkuName), string tier = null) { throw null; }
    }
    public partial class CustomerManagedKeyEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption>
    {
        public CustomerManagedKeyEncryption() { }
        public Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public string KeyEncryptionKeyUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomerManagedKeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity>
    {
        public CustomerManagedKeyEncryptionKeyIdentity() { }
        public System.Guid? DelegatedIdentityClientId { get { throw null; } set { } }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureEncryption : System.IEquatable<Azure.ResourceManager.Maps.Models.InfrastructureEncryption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureEncryption(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.InfrastructureEncryption Disabled { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.InfrastructureEncryption Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.InfrastructureEncryption other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.InfrastructureEncryption left, Azure.ResourceManager.Maps.Models.InfrastructureEncryption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.InfrastructureEncryption (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.InfrastructureEncryption? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.InfrastructureEncryption left, Azure.ResourceManager.Maps.Models.InfrastructureEncryption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocationsItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.LocationsItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.LocationsItem>
    {
        public LocationsItem(string locationName) { }
        public string LocationName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.LocationsItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.LocationsItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.LocationsItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.LocationsItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.LocationsItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.LocationsItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.LocationsItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.LocationsItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.LocationsItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsAccountKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountKeys>
    {
        internal MapsAccountKeys() { }
        public string PrimaryKey { get { throw null; } }
        public System.DateTimeOffset? PrimaryKeyLastUpdatedOn { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        public System.DateTimeOffset? SecondaryKeyLastUpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountKeys JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountKeys PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsAccountKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsAccountKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsAccountKind : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsAccountKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsAccountKind(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsAccountKind Gen2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsAccountKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsAccountKind left, Azure.ResourceManager.Maps.Models.MapsAccountKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsAccountKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsAccountKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsAccountKind left, Azure.ResourceManager.Maps.Models.MapsAccountKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountPatch>
    {
        public MapsAccountPatch() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.MapsCorsRule> CorsRules { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsAccountKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.MapsLinkedResource> LinkedResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.LocationsItem> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Maps.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.Guid? UniqueId { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsAccountProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountProperties>
    {
        public MapsAccountProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.MapsCorsRule> CorsRules { get { throw null; } }
        public bool? DisableLocalAuth { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsEncryption Encryption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.MapsLinkedResource> LinkedResources { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Maps.Models.LocationsItem> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Maps.MapsPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Maps.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Guid? UniqueId { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsAccountProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsAccountProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsAccountSasContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountSasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasContent>
    {
        public MapsAccountSasContent(Azure.ResourceManager.Maps.Models.MapsSigningKey signingKey, string principalId, int maxRatePerSecond, string start, string expiry) { }
        public string Expiry { get { throw null; } }
        public int MaxRatePerSecond { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public System.Collections.Generic.IList<string> Regions { get { throw null; } }
        public Azure.ResourceManager.Maps.Models.MapsSigningKey SigningKey { get { throw null; } }
        public string Start { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountSasContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountSasContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsAccountSasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountSasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountSasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsAccountSasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsAccountSasToken : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>
    {
        internal MapsAccountSasToken() { }
        public string AccountSasToken { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountSasToken JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsAccountSasToken PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsAccountSasToken System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsAccountSasToken System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsAccountSasToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsCorsRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCorsRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCorsRule>
    {
        public MapsCorsRule(System.Collections.Generic.IEnumerable<string> allowedOrigins) { }
        public System.Collections.Generic.IList<string> AllowedOrigins { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsCorsRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsCorsRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsCorsRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCorsRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCorsRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsCorsRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCorsRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCorsRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCorsRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsCreatorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCreatorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorPatch>
    {
        public MapsCreatorPatch() { }
        public int? ConsumedStorageUnitSizeInBytes { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public int StorageUnits { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public int? TotalStorageUnitSizeInBytes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsCreatorPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsCreatorPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsCreatorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCreatorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCreatorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsCreatorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsCreatorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCreatorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorProperties>
    {
        public MapsCreatorProperties(int storageUnits) { }
        public int? ConsumedStorageUnitSizeInBytes { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public int StorageUnits { get { throw null; } set { } }
        public int? TotalStorageUnitSizeInBytes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsCreatorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsCreatorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsCreatorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCreatorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsCreatorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsCreatorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsCreatorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MapsEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsEncryption>
    {
        public MapsEncryption() { }
        public Azure.ResourceManager.Maps.Models.CustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.InfrastructureEncryption? InfrastructureEncryption { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsIdentityType : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsIdentityType DelegatedResourceIdentity { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsIdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsIdentityType left, Azure.ResourceManager.Maps.Models.MapsIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsIdentityType left, Azure.ResourceManager.Maps.Models.MapsIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsKeySpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsKeySpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsKeySpecification>
    {
        public MapsKeySpecification(Azure.ResourceManager.Maps.Models.MapsKeyType keyType) { }
        public Azure.ResourceManager.Maps.Models.MapsKeyType KeyType { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsKeySpecification JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsKeySpecification PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsKeySpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsKeySpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsKeySpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsKeySpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsKeySpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsKeySpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsKeySpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsKeyType : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsKeyType(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsKeyType Primary { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsKeyType Secondary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsKeyType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsKeyType left, Azure.ResourceManager.Maps.Models.MapsKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsKeyType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsKeyType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsKeyType left, Azure.ResourceManager.Maps.Models.MapsKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsLinkedResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsLinkedResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsLinkedResource>
    {
        public MapsLinkedResource(string uniqueName, string id) { }
        public string Id { get { throw null; } set { } }
        public string UniqueName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsLinkedResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsLinkedResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsLinkedResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsLinkedResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsLinkedResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsLinkedResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsLinkedResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsLinkedResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsLinkedResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Maps.Models.MapsPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState>
    {
        public MapsPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Maps.Models.MapsPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsSigningKey : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsSigningKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsSigningKey(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsSigningKey ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsSigningKey PrimaryKey { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.MapsSigningKey SecondaryKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsSigningKey other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsSigningKey left, Azure.ResourceManager.Maps.Models.MapsSigningKey right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsSigningKey (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsSigningKey? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsSigningKey left, Azure.ResourceManager.Maps.Models.MapsSigningKey right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MapsSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsSku>
    {
        public MapsSku(Azure.ResourceManager.Maps.Models.MapsSkuName name) { }
        public Azure.ResourceManager.Maps.Models.MapsSkuName Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.Maps.Models.MapsSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Maps.Models.MapsSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Maps.Models.MapsSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Maps.Models.MapsSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Maps.Models.MapsSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Maps.Models.MapsSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MapsSkuName : System.IEquatable<Azure.ResourceManager.Maps.Models.MapsSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MapsSkuName(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.MapsSkuName G2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.MapsSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.MapsSkuName left, Azure.ResourceManager.Maps.Models.MapsSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.MapsSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.MapsSkuName left, Azure.ResourceManager.Maps.Models.MapsSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Maps.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Maps.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Maps.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Maps.Models.PublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Maps.Models.PublicNetworkAccess left, Azure.ResourceManager.Maps.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.PublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Maps.Models.PublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Maps.Models.PublicNetworkAccess left, Azure.ResourceManager.Maps.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
}
