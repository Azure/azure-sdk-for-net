namespace Azure.ResourceManager.Discovery
{
    public partial class AzureResourceManagerDiscoveryContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDiscoveryContext() { }
        public static Azure.ResourceManager.Discovery.AzureResourceManagerDiscoveryContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BookshelfPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected BookshelfPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BookshelfPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>
    {
        public BookshelfPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BookshelfPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BookshelfPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string bookshelfName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BookshelfPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BookshelfPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string bookshelfName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BookshelfPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected BookshelfPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BookshelfPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>
    {
        internal BookshelfPrivateLinkResourceData() { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryBookshelfCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>, System.Collections.IEnumerable
    {
        protected DiscoveryBookshelfCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bookshelfName, Azure.ResourceManager.Discovery.DiscoveryBookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bookshelfName, Azure.ResourceManager.Discovery.DiscoveryBookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> Get(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> GetAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetIfExists(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> GetIfExistsAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryBookshelfData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>
    {
        public DiscoveryBookshelfData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.BookshelfProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryBookshelfData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryBookshelfData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryBookshelfResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryBookshelfResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryBookshelfData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string bookshelfName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> GetBookshelfPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>> GetBookshelfPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionCollection GetBookshelfPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> GetBookshelfPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>> GetBookshelfPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceCollection GetBookshelfPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryBookshelfData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryBookshelfData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryBookshelfData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryBookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryBookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryChatModelDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>, System.Collections.IEnumerable
    {
        protected DiscoveryChatModelDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string chatModelDeploymentName, Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string chatModelDeploymentName, Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> Get(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> GetAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> GetIfExists(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> GetIfExistsAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryChatModelDeploymentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>
    {
        public DiscoveryChatModelDeploymentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryChatModelDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryChatModelDeploymentResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string chatModelDeploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DiscoveryExtensions
    {
        public static Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource GetBookshelfPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource GetBookshelfPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetDiscoveryBookshelf(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> GetDiscoveryBookshelfAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryBookshelfResource GetDiscoveryBookshelfResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryBookshelfCollection GetDiscoveryBookshelves(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetDiscoveryBookshelves(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetDiscoveryBookshelvesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource GetDiscoveryChatModelDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryNodePoolResource GetDiscoveryNodePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryProjectResource GetDiscoveryProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource GetDiscoveryStorageAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetDiscoveryStorageContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> GetDiscoveryStorageContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource GetDiscoveryStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryStorageContainerCollection GetDiscoveryStorageContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetDiscoveryStorageContainers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetDiscoveryStorageContainersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetDiscoverySupercomputer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> GetDiscoverySupercomputerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoverySupercomputerResource GetDiscoverySupercomputerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoverySupercomputerCollection GetDiscoverySupercomputers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetDiscoverySupercomputers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetDiscoverySupercomputersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetDiscoveryTool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource>> GetDiscoveryToolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryToolResource GetDiscoveryToolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryToolCollection GetDiscoveryTools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetDiscoveryTools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetDiscoveryToolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetDiscoveryWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> GetDiscoveryWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource GetDiscoveryWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryWorkspaceCollection GetDiscoveryWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetDiscoveryWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetDiscoveryWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource GetWorkspacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource GetWorkspacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DiscoveryNodePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>, System.Collections.IEnumerable
    {
        protected DiscoveryNodePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.Discovery.DiscoveryNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.Discovery.DiscoveryNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> Get(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> GetAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> GetIfExists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> GetIfExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryNodePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>
    {
        public DiscoveryNodePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryNodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryNodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryNodePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryNodePoolResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryNodePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string supercomputerName, string nodePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryNodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryNodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryNodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryNodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryProjectResource>, System.Collections.IEnumerable
    {
        protected DiscoveryProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Discovery.DiscoveryProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Discovery.DiscoveryProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>
    {
        public DiscoveryProjectData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryProjectResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryStorageAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>, System.Collections.IEnumerable
    {
        protected DiscoveryStorageAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageAssetName, Azure.ResourceManager.Discovery.DiscoveryStorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageAssetName, Azure.ResourceManager.Discovery.DiscoveryStorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> Get(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> GetAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> GetIfExists(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> GetIfExistsAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryStorageAssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>
    {
        public DiscoveryStorageAssetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryStorageAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryStorageAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryStorageAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryStorageAssetResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryStorageAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName, string storageAssetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryStorageAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryStorageAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryStorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryStorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryStorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>, System.Collections.IEnumerable
    {
        protected DiscoveryStorageContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Discovery.DiscoveryStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Discovery.DiscoveryStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryStorageContainerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>
    {
        public DiscoveryStorageContainerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryStorageContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryStorageContainerResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryStorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource> GetDiscoveryStorageAsset(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource>> GetDiscoveryStorageAssetAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryStorageAssetCollection GetDiscoveryStorageAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryStorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryStorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryStorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryStorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoverySupercomputerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>, System.Collections.IEnumerable
    {
        protected DiscoverySupercomputerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string supercomputerName, Azure.ResourceManager.Discovery.DiscoverySupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string supercomputerName, Azure.ResourceManager.Discovery.DiscoverySupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> Get(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> GetAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetIfExists(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> GetIfExistsAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoverySupercomputerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>
    {
        public DiscoverySupercomputerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoverySupercomputerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoverySupercomputerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoverySupercomputerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoverySupercomputerResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoverySupercomputerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string supercomputerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource> GetDiscoveryNodePool(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryNodePoolResource>> GetDiscoveryNodePoolAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryNodePoolCollection GetDiscoveryNodePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoverySupercomputerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoverySupercomputerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoverySupercomputerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoverySupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoverySupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryToolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryToolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryToolResource>, System.Collections.IEnumerable
    {
        protected DiscoveryToolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryToolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string toolName, Azure.ResourceManager.Discovery.DiscoveryToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryToolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string toolName, Azure.ResourceManager.Discovery.DiscoveryToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource> Get(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource>> GetAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetIfExists(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryToolResource>> GetIfExistsAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryToolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryToolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryToolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryToolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryToolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryToolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>
    {
        public DiscoveryToolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryToolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryToolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryToolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryToolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryToolResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryToolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string toolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryToolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryToolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryToolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryToolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryToolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiscoveryWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>, System.Collections.IEnumerable
    {
        protected DiscoveryWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Discovery.DiscoveryWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Discovery.DiscoveryWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiscoveryWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>
    {
        public DiscoveryWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiscoveryWorkspaceResource() { }
        public virtual Azure.ResourceManager.Discovery.DiscoveryWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource> GetDiscoveryChatModelDeployment(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource>> GetDiscoveryChatModelDeploymentAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentCollection GetDiscoveryChatModelDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource> GetDiscoveryProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryProjectResource>> GetDiscoveryProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryProjectCollection GetDiscoveryProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> GetWorkspacePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>> GetWorkspacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionCollection GetWorkspacePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> GetWorkspacePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>> GetWorkspacePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceCollection GetWorkspacePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.DiscoveryWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.DiscoveryWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.DiscoveryWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.DiscoveryWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected WorkspacePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspacePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>
    {
        public WorkspacePrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspacePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspacePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspacePrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspacePrivateLinkResource() { }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspacePrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected WorkspacePrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspacePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>
    {
        internal WorkspacePrivateLinkResourceData() { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Discovery.Mocking
{
    public partial class MockableDiscoveryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDiscoveryArmClient() { }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource GetBookshelfPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource GetBookshelfPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryBookshelfResource GetDiscoveryBookshelfResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentResource GetDiscoveryChatModelDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryNodePoolResource GetDiscoveryNodePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryProjectResource GetDiscoveryProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryStorageAssetResource GetDiscoveryStorageAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource GetDiscoveryStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoverySupercomputerResource GetDiscoverySupercomputerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryToolResource GetDiscoveryToolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource GetDiscoveryWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource GetWorkspacePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource GetWorkspacePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDiscoveryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDiscoveryResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetDiscoveryBookshelf(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource>> GetDiscoveryBookshelfAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryBookshelfCollection GetDiscoveryBookshelves() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetDiscoveryStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource>> GetDiscoveryStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryStorageContainerCollection GetDiscoveryStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetDiscoverySupercomputer(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource>> GetDiscoverySupercomputerAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoverySupercomputerCollection GetDiscoverySupercomputers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetDiscoveryTool(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryToolResource>> GetDiscoveryToolAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryToolCollection GetDiscoveryTools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetDiscoveryWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource>> GetDiscoveryWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.DiscoveryWorkspaceCollection GetDiscoveryWorkspaces() { throw null; }
    }
    public partial class MockableDiscoverySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDiscoverySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetDiscoveryBookshelves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryBookshelfResource> GetDiscoveryBookshelvesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetDiscoveryStorageContainers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryStorageContainerResource> GetDiscoveryStorageContainersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetDiscoverySupercomputers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoverySupercomputerResource> GetDiscoverySupercomputersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetDiscoveryTools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryToolResource> GetDiscoveryToolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetDiscoveryWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.DiscoveryWorkspaceResource> GetDiscoveryWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Discovery.Models
{
    public static partial class ArmDiscoveryModelFactory
    {
        public static Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore AzureNetAppFilesStore(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol? mountProtocol = default(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol?), Azure.Core.ResourceIdentifier netAppVolumeId = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore AzureStorageBlobStore(Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol? mountProtocol = default(Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol?), Azure.Core.ResourceIdentifier storageAccountId = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties BookshelfKeyVaultProperties(System.Uri keyVaultUri = null, string keyName = null, string keyVersion = null, string identityClientId = null) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData BookshelfPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData BookshelfPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.BookshelfProperties BookshelfProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> workloadIdentities = null, Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys? customerManagedKeys = default(Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys?), Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties keyVaultProperties = null, Azure.Core.ResourceIdentifier logAnalyticsClusterId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess?), Azure.Core.ResourceIdentifier privateEndpointSubnetId = null, Azure.Core.ResourceIdentifier searchSubnetId = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null, System.Uri bookshelfUri = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryBookshelfData DiscoveryBookshelfData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.BookshelfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryChatModelDeploymentData DiscoveryChatModelDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties DiscoveryChatModelDeploymentProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), string modelFormat = null, string modelName = null, string modelVersion = null, string skuName = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties DiscoveryKeyVaultProperties(System.Uri keyVaultUri = null, string keyName = null, string keyVersion = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference DiscoveryManagedIdentityReference(Azure.Core.ResourceIdentifier id = null, System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource DiscoveryMoboBrokerResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryNodePoolData DiscoveryNodePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties DiscoveryNodePoolProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.Discovery.Models.DiscoveryVmSize vmSize = default(Azure.ResourceManager.Discovery.Models.DiscoveryVmSize), int maxNodeCount = 0, int? minNodeCount = default(int?), Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority? scaleSetPriority = default(Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority?), int? osDiskSizeGb = default(int?), int? imageCacheLowerThreshold = default(int?), int? imageCacheUpperThreshold = default(int?)) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection DiscoveryPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties DiscoveryPrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties DiscoveryPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState DiscoveryPrivateLinkServiceConnectionState(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryProjectData DiscoveryProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties DiscoveryProjectProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), System.Uri foundryProjectEndpoint = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> storageContainerIds = null, string behaviorPreferences = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryStorageAssetData DiscoveryStorageAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties DiscoveryStorageAssetProperties(string description = null, Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), string path = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryStorageContainerData DiscoveryStorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties DiscoveryStorageContainerProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore storageStore = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore DiscoveryStorageStore(string kind = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoverySupercomputerData DiscoverySupercomputerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties properties = null, Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities DiscoverySupercomputerIdentities(Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference clusterIdentity = null, Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference kubeletIdentity = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> workloadIdentities = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties DiscoverySupercomputerProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier managementSubnetId = null, Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType? outboundType = default(Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType?), Azure.ResourceManager.Discovery.Models.DiscoverySystemSku? systemSku = default(Azure.ResourceManager.Discovery.Models.DiscoverySystemSku?), Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities identities = null, Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys? customerManagedKeys = default(Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys?), Azure.Core.ResourceIdentifier diskEncryptionSetId = null, Azure.Core.ResourceIdentifier logAnalyticsClusterId = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity DiscoverySystemAssignedServiceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType type = default(Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType)) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryToolData DiscoveryToolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties DiscoveryToolProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), string version = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, System.Collections.Generic.IDictionary<string, System.BinaryData> definitionContent = null) { throw null; }
        public static Azure.ResourceManager.Discovery.DiscoveryWorkspaceData DiscoveryWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties DiscoveryWorkspaceProperties(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> supercomputerIds = null, System.Uri workspaceApiUri = null, System.Uri workspaceUiUri = null, Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference workspaceIdentity = null, Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys? customerManagedKeys = default(Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys?), Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties keyVaultProperties = null, Azure.Core.ResourceIdentifier logAnalyticsClusterId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess?), Azure.Core.ResourceIdentifier agentSubnetId = null, Azure.Core.ResourceIdentifier privateEndpointSubnetId = null, Azure.Core.ResourceIdentifier workspaceSubnetId = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData WorkspacePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData WorkspacePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties properties = null) { throw null; }
    }
    public partial class AzureNetAppFilesStore : Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>
    {
        public AzureNetAppFilesStore(Azure.Core.ResourceIdentifier netAppVolumeId) { }
        public Azure.ResourceManager.Discovery.Models.NetAppMountProtocol? MountProtocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetAppVolumeId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageBlobStore : Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>
    {
        public AzureStorageBlobStore(Azure.Core.ResourceIdentifier storageAccountId) { }
        public Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol? MountProtocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlobStorageMountProtocol : System.IEquatable<Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlobStorageMountProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol BlobfuseCaching { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol Nfs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol left, Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol left, Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BookshelfKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties>
    {
        public BookshelfKeyVaultProperties(System.Uri keyVaultUri, string keyName, string identityClientId) { }
        public string IdentityClientId { get { throw null; } set { } }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BookshelfProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.BookshelfProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfProperties>
    {
        public BookshelfProperties() { }
        public System.Uri BookshelfUri { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys? CustomerManagedKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsClusterId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SearchSubnetId { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> WorkloadIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.BookshelfProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.BookshelfProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.BookshelfProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.BookshelfProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.BookshelfProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.BookshelfProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.BookshelfProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryChatModelDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties>
    {
        public DiscoveryChatModelDeploymentProperties(string modelFormat, string modelName) { }
        public int? Capacity { get { throw null; } set { } }
        public string ModelFormat { get { throw null; } set { } }
        public string ModelName { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryChatModelDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryCustomerManagedKeys : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryCustomerManagedKeys(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys Disabled { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys left, Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys left, Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties>
    {
        public DiscoveryKeyVaultProperties(System.Uri keyVaultUri, string keyName) { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryManagedIdentityReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference>
    {
        public DiscoveryManagedIdentityReference(Azure.Core.ResourceIdentifier id) { }
        public System.Guid? ClientId { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryMoboBrokerResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource>
    {
        internal DiscoveryMoboBrokerResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryNetworkEgressType : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryNetworkEgressType(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType LoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType left, Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType left, Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryNodePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties>
    {
        public DiscoveryNodePoolProperties(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Discovery.Models.DiscoveryVmSize vmSize, int maxNodeCount) { }
        public int? ImageCacheLowerThreshold { get { throw null; } set { } }
        public int? ImageCacheUpperThreshold { get { throw null; } set { } }
        public int MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
        public int? OsDiskSizeGb { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority? ScaleSetPriority { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryVmSize VmSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryNodePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>
    {
        internal DiscoveryPrivateEndpointConnection() { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties>
    {
        public DiscoveryPrivateEndpointConnectionProperties(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties>
    {
        internal DiscoveryPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState>
    {
        public DiscoveryPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryProjectProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties>
    {
        public DiscoveryProjectProperties() { }
        public string BehaviorPreferences { get { throw null; } set { } }
        public System.Uri FoundryProjectEndpoint { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> StorageContainerIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryProjectProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryProvisioningState : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState left, Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState left, Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess left, Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess left, Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryScaleSetPriority : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryScaleSetPriority(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority Regular { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority left, Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority left, Azure.ResourceManager.Discovery.Models.DiscoveryScaleSetPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryStorageAssetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties>
    {
        public DiscoveryStorageAssetProperties(string description) { }
        public string Description { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageAssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryStorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties>
    {
        public DiscoveryStorageContainerProperties(Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore storageStore) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore StorageStore { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DiscoveryStorageStore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore>
    {
        internal DiscoveryStorageStore() { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryStorageStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoverySupercomputerIdentities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities>
    {
        public DiscoverySupercomputerIdentities(Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference clusterIdentity, Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference kubeletIdentity) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference ClusterIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference KubeletIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> WorkloadIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoverySupercomputerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties>
    {
        public DiscoverySupercomputerProperties(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities identities) { }
        public Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys? CustomerManagedKeys { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerIdentities Identities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsClusterId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagementSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryNetworkEgressType? OutboundType { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoverySystemSku? SystemSku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySupercomputerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoverySystemAssignedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity>
    {
        public DiscoverySystemAssignedServiceIdentity(Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoverySystemAssignedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoverySystemAssignedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType left, Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType left, Azure.ResourceManager.Discovery.Models.DiscoverySystemAssignedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoverySystemSku : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoverySystemSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoverySystemSku(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySystemSku StandardD4sV4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySystemSku StandardD4sV5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoverySystemSku StandardD4sV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoverySystemSku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoverySystemSku left, Azure.ResourceManager.Discovery.Models.DiscoverySystemSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoverySystemSku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoverySystemSku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoverySystemSku left, Azure.ResourceManager.Discovery.Models.DiscoverySystemSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryToolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties>
    {
        public DiscoveryToolProperties(string version, System.Collections.Generic.IDictionary<string, System.BinaryData> definitionContent) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> DefinitionContent { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryToolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryVmSize : System.IEquatable<Azure.ResourceManager.Discovery.Models.DiscoveryVmSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryVmSize(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNC16asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNC24adsA100V4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNC48adsA100V4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNC4asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNC64asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNC8asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNC96adsA100V4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardND40rsV2 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNV12adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNV24adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNV36admsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNV36adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNV6adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryVmSize StandardNV72adsA10V5 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.DiscoveryVmSize other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.DiscoveryVmSize left, Azure.ResourceManager.Discovery.Models.DiscoveryVmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryVmSize (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.DiscoveryVmSize? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.DiscoveryVmSize left, Azure.ResourceManager.Discovery.Models.DiscoveryVmSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties>
    {
        public DiscoveryWorkspaceProperties(Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference workspaceIdentity) { }
        public Azure.Core.ResourceIdentifier AgentSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryCustomerManagedKeys? CustomerManagedKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsClusterId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.DiscoveryMoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SupercomputerIds { get { throw null; } }
        public System.Uri WorkspaceApiUri { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryManagedIdentityReference WorkspaceIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceSubnetId { get { throw null; } set { } }
        public System.Uri WorkspaceUiUri { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppMountProtocol : System.IEquatable<Azure.ResourceManager.Discovery.Models.NetAppMountProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppMountProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.NetAppMountProtocol Nfs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol left, Azure.ResourceManager.Discovery.Models.NetAppMountProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.NetAppMountProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.NetAppMountProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol left, Azure.ResourceManager.Discovery.Models.NetAppMountProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
}
