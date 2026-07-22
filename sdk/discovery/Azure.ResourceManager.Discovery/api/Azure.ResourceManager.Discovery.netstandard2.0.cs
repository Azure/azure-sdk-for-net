namespace Azure.ResourceManager.Discovery
{
    public partial class AzureResourceManagerDiscoveryContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDiscoveryContext() { }
        public static Azure.ResourceManager.Discovery.AzureResourceManagerDiscoveryContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BookshelfCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.BookshelfResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.BookshelfResource>, System.Collections.IEnumerable
    {
        protected BookshelfCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bookshelfName, Azure.ResourceManager.Discovery.BookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bookshelfName, Azure.ResourceManager.Discovery.BookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource> Get(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.BookshelfResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.BookshelfResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource>> GetAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.BookshelfResource> GetIfExists(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.BookshelfResource>> GetIfExistsAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.BookshelfResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.BookshelfResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.BookshelfResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.BookshelfResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BookshelfData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>
    {
        public BookshelfData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.BookshelfProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.BookshelfData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.BookshelfData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
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
    public partial class BookshelfResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BookshelfResource() { }
        public virtual Azure.ResourceManager.Discovery.BookshelfData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string bookshelfName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource> GetBookshelfPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource>> GetBookshelfPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionCollection GetBookshelfPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource> GetBookshelfPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource>> GetBookshelfPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceCollection GetBookshelfPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.BookshelfData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.BookshelfData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.BookshelfData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.BookshelfData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.BookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.BookshelfResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.BookshelfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ChatModelDeploymentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>, System.Collections.IEnumerable
    {
        protected ChatModelDeploymentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string chatModelDeploymentName, Azure.ResourceManager.Discovery.ChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string chatModelDeploymentName, Azure.ResourceManager.Discovery.ChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> Get(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> GetAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> GetIfExists(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> GetIfExistsAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ChatModelDeploymentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>
    {
        public ChatModelDeploymentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.ChatModelDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.ChatModelDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatModelDeploymentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ChatModelDeploymentResource() { }
        public virtual Azure.ResourceManager.Discovery.ChatModelDeploymentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string chatModelDeploymentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.ChatModelDeploymentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.ChatModelDeploymentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ChatModelDeploymentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.ChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.ChatModelDeploymentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DiscoveryExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource> GetBookshelf(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource>> GetBookshelfAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource GetBookshelfPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource GetBookshelfPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfResource GetBookshelfResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfCollection GetBookshelves(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.BookshelfResource> GetBookshelves(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.BookshelfResource> GetBookshelvesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.ChatModelDeploymentResource GetChatModelDeploymentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.NodePoolResource GetNodePoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.ProjectResource GetProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.StorageAssetResource GetStorageAssetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource> GetStorageContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource>> GetStorageContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.StorageContainerResource GetStorageContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.StorageContainerCollection GetStorageContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.StorageContainerResource> GetStorageContainers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.StorageContainerResource> GetStorageContainersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource> GetSupercomputer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource>> GetSupercomputerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.SupercomputerResource GetSupercomputerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.SupercomputerCollection GetSupercomputers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.SupercomputerResource> GetSupercomputers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.SupercomputerResource> GetSupercomputersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.ToolResource> GetTool(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ToolResource>> GetToolAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.ToolResource GetToolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.ToolCollection GetTools(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.ToolResource> GetTools(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.ToolResource> GetToolsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource> GetWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource>> GetWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource GetWorkspacePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource GetWorkspacePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspaceResource GetWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspaceCollection GetWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Discovery.WorkspaceResource> GetWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Discovery.WorkspaceResource> GetWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NodePoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.NodePoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.NodePoolResource>, System.Collections.IEnumerable
    {
        protected NodePoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.NodePoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.Discovery.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.NodePoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string nodePoolName, Azure.ResourceManager.Discovery.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource> Get(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.NodePoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.NodePoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource>> GetAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.NodePoolResource> GetIfExists(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.NodePoolResource>> GetIfExistsAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.NodePoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.NodePoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.NodePoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.NodePoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NodePoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.NodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>
    {
        public NodePoolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.NodePoolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.NodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.NodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.NodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.NodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodePoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.NodePoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NodePoolResource() { }
        public virtual Azure.ResourceManager.Discovery.NodePoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string supercomputerName, string nodePoolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.NodePoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.NodePoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.NodePoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.NodePoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.NodePoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.NodePoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.NodePoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.NodePoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.ProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.ProjectResource>, System.Collections.IEnumerable
    {
        protected ProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Discovery.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.Discovery.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.ProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.ProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.ProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.ProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.ProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.ProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.ProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.ProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProjectData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>
    {
        public ProjectData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.ProjectProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.ProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.ProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProjectResource() { }
        public virtual Azure.ResourceManager.Discovery.ProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ProjectResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ProjectResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ProjectResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ProjectResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ProjectResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ProjectResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.ProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.ProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.ProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageAssetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.StorageAssetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.StorageAssetResource>, System.Collections.IEnumerable
    {
        protected StorageAssetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageAssetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageAssetName, Azure.ResourceManager.Discovery.StorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageAssetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageAssetName, Azure.ResourceManager.Discovery.StorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource> Get(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.StorageAssetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.StorageAssetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource>> GetAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.StorageAssetResource> GetIfExists(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.StorageAssetResource>> GetIfExistsAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.StorageAssetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.StorageAssetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.StorageAssetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.StorageAssetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageAssetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>
    {
        public StorageAssetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.StorageAssetProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.StorageAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.StorageAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAssetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageAssetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageAssetResource() { }
        public virtual Azure.ResourceManager.Discovery.StorageAssetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName, string storageAssetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.StorageAssetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageAssetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageAssetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.StorageAssetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageAssetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageAssetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.StorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageAssetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.StorageAssetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class StorageContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.StorageContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.StorageContainerResource>, System.Collections.IEnumerable
    {
        protected StorageContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Discovery.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string storageContainerName, Azure.ResourceManager.Discovery.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource> Get(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.StorageContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.StorageContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource>> GetAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.StorageContainerResource> GetIfExists(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.StorageContainerResource>> GetIfExistsAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.StorageContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.StorageContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.StorageContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.StorageContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class StorageContainerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>
    {
        public StorageContainerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.StorageContainerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.StorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.StorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected StorageContainerResource() { }
        public virtual Azure.ResourceManager.Discovery.StorageContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string storageContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource> GetStorageAsset(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageAssetResource>> GetStorageAssetAsync(string storageAssetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.StorageAssetCollection GetStorageAssets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.StorageContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.StorageContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.StorageContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.StorageContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.StorageContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.StorageContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SupercomputerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.SupercomputerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.SupercomputerResource>, System.Collections.IEnumerable
    {
        protected SupercomputerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.SupercomputerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string supercomputerName, Azure.ResourceManager.Discovery.SupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.SupercomputerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string supercomputerName, Azure.ResourceManager.Discovery.SupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource> Get(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.SupercomputerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.SupercomputerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource>> GetAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.SupercomputerResource> GetIfExists(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.SupercomputerResource>> GetIfExistsAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.SupercomputerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.SupercomputerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.SupercomputerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.SupercomputerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SupercomputerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.SupercomputerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>
    {
        public SupercomputerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.SupercomputerProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.SupercomputerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.SupercomputerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.SupercomputerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.SupercomputerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupercomputerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.SupercomputerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SupercomputerResource() { }
        public virtual Azure.ResourceManager.Discovery.SupercomputerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string supercomputerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource> GetNodePool(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.NodePoolResource>> GetNodePoolAsync(string nodePoolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.NodePoolCollection GetNodePools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.SupercomputerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.SupercomputerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.SupercomputerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.SupercomputerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.SupercomputerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.SupercomputerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.SupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.SupercomputerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.SupercomputerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ToolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.ToolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.ToolResource>, System.Collections.IEnumerable
    {
        protected ToolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ToolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string toolName, Azure.ResourceManager.Discovery.ToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ToolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string toolName, Azure.ResourceManager.Discovery.ToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ToolResource> Get(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.ToolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.ToolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ToolResource>> GetAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.ToolResource> GetIfExists(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.ToolResource>> GetIfExistsAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.ToolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.ToolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.ToolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.ToolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ToolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ToolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>
    {
        public ToolData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.ToolProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.ToolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ToolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ToolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.ToolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ToolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ToolResource() { }
        public virtual Azure.ResourceManager.Discovery.ToolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ToolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ToolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string toolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ToolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ToolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ToolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ToolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ToolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ToolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.ToolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ToolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.ToolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.ToolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.ToolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ToolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.ToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.ToolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.ToolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.WorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.WorkspaceResource>, System.Collections.IEnumerable
    {
        protected WorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Discovery.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Discovery.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.WorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.WorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Discovery.WorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Discovery.WorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Discovery.WorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Discovery.WorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Discovery.WorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.WorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>
    {
        public WorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Discovery.Models.WorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.WorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.WorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
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
    public partial class WorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkspaceResource() { }
        public virtual Azure.ResourceManager.Discovery.WorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource> GetChatModelDeployment(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ChatModelDeploymentResource>> GetChatModelDeploymentAsync(string chatModelDeploymentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.ChatModelDeploymentCollection GetChatModelDeployments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ProjectResource> GetProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ProjectResource>> GetProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.ProjectCollection GetProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource> GetWorkspacePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource>> GetWorkspacePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionCollection GetWorkspacePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource> GetWorkspacePrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource>> GetWorkspacePrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceCollection GetWorkspacePrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Discovery.WorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.WorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.WorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.WorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Discovery.WorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Discovery.WorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Discovery.Mocking
{
    public partial class MockableDiscoveryArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDiscoveryArmClient() { }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionResource GetBookshelfPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfPrivateLinkResource GetBookshelfPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfResource GetBookshelfResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.ChatModelDeploymentResource GetChatModelDeploymentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.NodePoolResource GetNodePoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.ProjectResource GetProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.StorageAssetResource GetStorageAssetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.StorageContainerResource GetStorageContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.SupercomputerResource GetSupercomputerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.ToolResource GetToolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionResource GetWorkspacePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspacePrivateLinkResource GetWorkspacePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspaceResource GetWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDiscoveryResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDiscoveryResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource> GetBookshelf(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.BookshelfResource>> GetBookshelfAsync(string bookshelfName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.BookshelfCollection GetBookshelves() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource> GetStorageContainer(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.StorageContainerResource>> GetStorageContainerAsync(string storageContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.StorageContainerCollection GetStorageContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource> GetSupercomputer(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.SupercomputerResource>> GetSupercomputerAsync(string supercomputerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.SupercomputerCollection GetSupercomputers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.ToolResource> GetTool(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.ToolResource>> GetToolAsync(string toolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.ToolCollection GetTools() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource> GetWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Discovery.WorkspaceResource>> GetWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Discovery.WorkspaceCollection GetWorkspaces() { throw null; }
    }
    public partial class MockableDiscoverySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDiscoverySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.BookshelfResource> GetBookshelves(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.BookshelfResource> GetBookshelvesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.StorageContainerResource> GetStorageContainers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.StorageContainerResource> GetStorageContainersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.SupercomputerResource> GetSupercomputers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.SupercomputerResource> GetSupercomputersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.ToolResource> GetTools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.ToolResource> GetToolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Discovery.WorkspaceResource> GetWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Discovery.WorkspaceResource> GetWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Discovery.Models
{
    public static partial class ArmDiscoveryModelFactory
    {
        public static Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore AzureNetAppFilesStore(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol? mountProtocol = default(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol?), Azure.Core.ResourceIdentifier netAppVolumeId = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore AzureStorageBlobStore(Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol? mountProtocol = default(Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol?), Azure.Core.ResourceIdentifier storageAccountId = null) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfData BookshelfData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.BookshelfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties BookshelfKeyVaultProperties(System.Uri keyVaultUri = null, string keyName = null, string keyVersion = null, string identityClientId = null) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfPrivateEndpointConnectionData BookshelfPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.BookshelfPrivateLinkResourceData BookshelfPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.BookshelfProperties BookshelfProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> workloadIdentities = null, Azure.ResourceManager.Discovery.Models.CustomerManagedKeys? customerManagedKeys = default(Azure.ResourceManager.Discovery.Models.CustomerManagedKeys?), Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties keyVaultProperties = null, Azure.Core.ResourceIdentifier logAnalyticsClusterId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Discovery.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Discovery.Models.PublicNetworkAccess?), Azure.Core.ResourceIdentifier privateEndpointSubnetId = null, Azure.Core.ResourceIdentifier searchSubnetId = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null, System.Uri bookshelfUri = null) { throw null; }
        public static Azure.ResourceManager.Discovery.ChatModelDeploymentData ChatModelDeploymentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties ChatModelDeploymentProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), string modelFormat = null, string modelName = null, string modelVersion = null, string skuName = null, int? capacity = default(int?)) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection DiscoveryPrivateEndpointConnection(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties DiscoveryPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState DiscoveryPrivateLinkServiceConnectionState(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus? status = default(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointServiceConnectionStatus?), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.Identity Identity(Azure.Core.ResourceIdentifier id = null, System.Guid? principalId = default(System.Guid?), System.Guid? clientId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.KeyVaultProperties KeyVaultProperties(System.Uri keyVaultUri = null, string keyName = null, string keyVersion = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.MoboBrokerResource MoboBrokerResource(Azure.Core.ResourceIdentifier id = null) { throw null; }
        public static Azure.ResourceManager.Discovery.NodePoolData NodePoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.NodePoolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.NodePoolProperties NodePoolProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.Discovery.Models.VmSize vmSize = default(Azure.ResourceManager.Discovery.Models.VmSize), int maxNodeCount = 0, int? minNodeCount = default(int?), Azure.ResourceManager.Discovery.Models.ScaleSetPriority? scaleSetPriority = default(Azure.ResourceManager.Discovery.Models.ScaleSetPriority?), int? osDiskSizeGb = default(int?), int? imageCacheLowerThreshold = default(int?), int? imageCacheUpperThreshold = default(int?)) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Discovery.ProjectData ProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.ProjectProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.ProjectProperties ProjectProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), System.Uri foundryProjectEndpoint = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> storageContainerIds = null, string behaviorPreferences = null) { throw null; }
        public static Azure.ResourceManager.Discovery.StorageAssetData StorageAssetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.StorageAssetProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.StorageAssetProperties StorageAssetProperties(string description = null, Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), string path = null) { throw null; }
        public static Azure.ResourceManager.Discovery.StorageContainerData StorageContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.StorageContainerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.StorageContainerProperties StorageContainerProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), Azure.ResourceManager.Discovery.Models.StorageStore storageStore = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.StorageStore StorageStore(string kind = null) { throw null; }
        public static Azure.ResourceManager.Discovery.SupercomputerData SupercomputerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.SupercomputerProperties properties = null, Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.SupercomputerIdentities SupercomputerIdentities(Azure.ResourceManager.Discovery.Models.Identity clusterIdentity = null, Azure.ResourceManager.Discovery.Models.Identity kubeletIdentity = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> workloadIdentities = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.SupercomputerProperties SupercomputerProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), Azure.Core.ResourceIdentifier subnetId = null, Azure.Core.ResourceIdentifier managementSubnetId = null, Azure.ResourceManager.Discovery.Models.NetworkEgressType? outboundType = default(Azure.ResourceManager.Discovery.Models.NetworkEgressType?), Azure.ResourceManager.Discovery.Models.SystemSku? systemSku = default(Azure.ResourceManager.Discovery.Models.SystemSku?), Azure.ResourceManager.Discovery.Models.SupercomputerIdentities identities = null, Azure.ResourceManager.Discovery.Models.CustomerManagedKeys? customerManagedKeys = default(Azure.ResourceManager.Discovery.Models.CustomerManagedKeys?), Azure.Core.ResourceIdentifier diskEncryptionSetId = null, Azure.Core.ResourceIdentifier logAnalyticsClusterId = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity SystemAssignedServiceIdentity(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType type = default(Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType)) { throw null; }
        public static Azure.ResourceManager.Discovery.ToolData ToolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.ToolProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.ToolProperties ToolProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), string version = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, System.Collections.Generic.IDictionary<string, System.BinaryData> definitionContent = null) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspaceData WorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Discovery.Models.WorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateEndpointConnectionData WorkspacePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.WorkspacePrivateLinkResourceData WorkspacePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.WorkspaceProperties WorkspaceProperties(Azure.ResourceManager.Discovery.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Discovery.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> supercomputerIds = null, System.Uri workspaceApiUri = null, System.Uri workspaceUiUri = null, Azure.ResourceManager.Discovery.Models.Identity workspaceIdentity = null, Azure.ResourceManager.Discovery.Models.CustomerManagedKeys? customerManagedKeys = default(Azure.ResourceManager.Discovery.Models.CustomerManagedKeys?), Azure.ResourceManager.Discovery.Models.KeyVaultProperties keyVaultProperties = null, Azure.Core.ResourceIdentifier logAnalyticsClusterId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> privateEndpointConnections = null, Azure.ResourceManager.Discovery.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Discovery.Models.PublicNetworkAccess?), Azure.Core.ResourceIdentifier agentSubnetId = null, Azure.Core.ResourceIdentifier privateEndpointSubnetId = null, Azure.Core.ResourceIdentifier workspaceSubnetId = null, string managedResourceGroup = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Discovery.Models.MoboBrokerResource> managedOnBehalfOfMoboBrokerResources = null) { throw null; }
    }
    public partial class AzureNetAppFilesStore : Azure.ResourceManager.Discovery.Models.StorageStore, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>
    {
        public AzureNetAppFilesStore(Azure.Core.ResourceIdentifier netAppVolumeId) { }
        public Azure.ResourceManager.Discovery.Models.NetAppMountProtocol? MountProtocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier NetAppVolumeId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Discovery.Models.StorageStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Discovery.Models.StorageStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureNetAppFilesStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureStorageBlobStore : Azure.ResourceManager.Discovery.Models.StorageStore, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.AzureStorageBlobStore>
    {
        public AzureStorageBlobStore(Azure.Core.ResourceIdentifier storageAccountId) { }
        public Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol? MountProtocol { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        protected override Azure.ResourceManager.Discovery.Models.StorageStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Discovery.Models.StorageStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.Discovery.Models.BlobStorageMountProtocol NFS { get { throw null; } }
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
        public Azure.ResourceManager.Discovery.Models.CustomerManagedKeys? CustomerManagedKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.BookshelfKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsClusterId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
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
    public partial class ChatModelDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties>
    {
        public ChatModelDeploymentProperties(string modelFormat, string modelName) { }
        public int? Capacity { get { throw null; } set { } }
        public string ModelFormat { get { throw null; } set { } }
        public string ModelName { get { throw null; } set { } }
        public string ModelVersion { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SkuName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ChatModelDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomerManagedKeys : System.IEquatable<Azure.ResourceManager.Discovery.Models.CustomerManagedKeys>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomerManagedKeys(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.CustomerManagedKeys Disabled { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.CustomerManagedKeys Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.CustomerManagedKeys other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.CustomerManagedKeys left, Azure.ResourceManager.Discovery.Models.CustomerManagedKeys right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.CustomerManagedKeys (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.CustomerManagedKeys? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.CustomerManagedKeys left, Azure.ResourceManager.Discovery.Models.CustomerManagedKeys right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryPrivateEndpointConnection : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection>
    {
        internal DiscoveryPrivateEndpointConnection() { }
        public Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } }
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
    public partial class Identity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.Identity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.Identity>
    {
        public Identity(Azure.Core.ResourceIdentifier id) { }
        public System.Guid? ClientId { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.Identity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.Identity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.Identity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.Identity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.Identity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.Identity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.Identity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.Identity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.Identity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.KeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.KeyVaultProperties>
    {
        public KeyVaultProperties(System.Uri keyVaultUri, string keyName) { }
        public string KeyName { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.KeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.KeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.KeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.KeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.KeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.KeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.KeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.KeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.KeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoboBrokerResource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.MoboBrokerResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.MoboBrokerResource>
    {
        internal MoboBrokerResource() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.MoboBrokerResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.MoboBrokerResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.MoboBrokerResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.MoboBrokerResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.MoboBrokerResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.MoboBrokerResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.MoboBrokerResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.MoboBrokerResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.MoboBrokerResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppMountProtocol : System.IEquatable<Azure.ResourceManager.Discovery.Models.NetAppMountProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppMountProtocol(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.NetAppMountProtocol NFS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol left, Azure.ResourceManager.Discovery.Models.NetAppMountProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.NetAppMountProtocol (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.NetAppMountProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.NetAppMountProtocol left, Azure.ResourceManager.Discovery.Models.NetAppMountProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkEgressType : System.IEquatable<Azure.ResourceManager.Discovery.Models.NetworkEgressType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkEgressType(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.NetworkEgressType LoadBalancer { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.NetworkEgressType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.NetworkEgressType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.NetworkEgressType left, Azure.ResourceManager.Discovery.Models.NetworkEgressType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.NetworkEgressType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.NetworkEgressType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.NetworkEgressType left, Azure.ResourceManager.Discovery.Models.NetworkEgressType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NodePoolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.NodePoolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.NodePoolProperties>
    {
        public NodePoolProperties(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Discovery.Models.VmSize vmSize, int maxNodeCount) { }
        public int? ImageCacheLowerThreshold { get { throw null; } set { } }
        public int? ImageCacheUpperThreshold { get { throw null; } set { } }
        public int MaxNodeCount { get { throw null; } set { } }
        public int? MinNodeCount { get { throw null; } set { } }
        public int? OsDiskSizeGb { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.ScaleSetPriority? ScaleSetPriority { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.VmSize VmSize { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.NodePoolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.NodePoolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.NodePoolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.NodePoolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.NodePoolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.NodePoolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.NodePoolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.NodePoolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.NodePoolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ProjectProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ProjectProperties>
    {
        public ProjectProperties() { }
        public string BehaviorPreferences { get { throw null; } set { } }
        public System.Uri FoundryProjectEndpoint { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> StorageContainerIds { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.ProjectProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.ProjectProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.ProjectProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ProjectProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ProjectProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.ProjectProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ProjectProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ProjectProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ProjectProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Discovery.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.ProvisioningState left, Azure.ResourceManager.Discovery.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.ProvisioningState left, Azure.ResourceManager.Discovery.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Discovery.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.PublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.PublicNetworkAccess left, Azure.ResourceManager.Discovery.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.PublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.PublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.PublicNetworkAccess left, Azure.ResourceManager.Discovery.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScaleSetPriority : System.IEquatable<Azure.ResourceManager.Discovery.Models.ScaleSetPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScaleSetPriority(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.ScaleSetPriority Regular { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.ScaleSetPriority Spot { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.ScaleSetPriority other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.ScaleSetPriority left, Azure.ResourceManager.Discovery.Models.ScaleSetPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.ScaleSetPriority (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.ScaleSetPriority? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.ScaleSetPriority left, Azure.ResourceManager.Discovery.Models.ScaleSetPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageAssetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageAssetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageAssetProperties>
    {
        public StorageAssetProperties(string description) { }
        public string Description { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.StorageAssetProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.StorageAssetProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.StorageAssetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageAssetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageAssetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.StorageAssetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageAssetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageAssetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageAssetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageContainerProperties>
    {
        public StorageContainerProperties(Azure.ResourceManager.Discovery.Models.StorageStore storageStore) { }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.StorageStore StorageStore { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.StorageContainerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.StorageContainerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.StorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.StorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StorageStore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageStore>
    {
        internal StorageStore() { }
        protected virtual Azure.ResourceManager.Discovery.Models.StorageStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.StorageStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.StorageStore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.StorageStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.StorageStore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.StorageStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupercomputerIdentities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SupercomputerIdentities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerIdentities>
    {
        public SupercomputerIdentities(Azure.ResourceManager.Discovery.Models.Identity clusterIdentity, Azure.ResourceManager.Discovery.Models.Identity kubeletIdentity) { }
        public Azure.ResourceManager.Discovery.Models.Identity ClusterIdentity { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.Identity KubeletIdentity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> WorkloadIdentities { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.SupercomputerIdentities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.SupercomputerIdentities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.SupercomputerIdentities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SupercomputerIdentities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SupercomputerIdentities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.SupercomputerIdentities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerIdentities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerIdentities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerIdentities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupercomputerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SupercomputerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerProperties>
    {
        public SupercomputerProperties(Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.Discovery.Models.SupercomputerIdentities identities) { }
        public Azure.ResourceManager.Discovery.Models.CustomerManagedKeys? CustomerManagedKeys { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.SupercomputerIdentities Identities { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsClusterId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagementSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.NetworkEgressType? OutboundType { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.SystemSku? SystemSku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.SupercomputerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.SupercomputerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.SupercomputerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SupercomputerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SupercomputerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.SupercomputerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SupercomputerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemAssignedServiceIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity>
    {
        public SystemAssignedServiceIdentity(Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SystemAssignedServiceIdentityType : System.IEquatable<Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SystemAssignedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType SystemAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType left, Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType left, Azure.ResourceManager.Discovery.Models.SystemAssignedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SystemSku : System.IEquatable<Azure.ResourceManager.Discovery.Models.SystemSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SystemSku(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.SystemSku StandardD4sV4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.SystemSku StandardD4sV5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.SystemSku StandardD4sV6 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.SystemSku other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.SystemSku left, Azure.ResourceManager.Discovery.Models.SystemSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.SystemSku (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.SystemSku? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.SystemSku left, Azure.ResourceManager.Discovery.Models.SystemSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ToolProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ToolProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ToolProperties>
    {
        public ToolProperties(string version, System.Collections.Generic.IDictionary<string, System.BinaryData> definitionContent) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> DefinitionContent { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Discovery.Models.ToolProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.ToolProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.ToolProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ToolProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.ToolProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.ToolProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ToolProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ToolProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.ToolProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmSize : System.IEquatable<Azure.ResourceManager.Discovery.Models.VmSize>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmSize(string value) { throw null; }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNC16asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNC24adsA100V4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNC48adsA100V4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNC4asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNC64asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNC8asT4V3 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNC96adsA100V4 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardND40rsV2 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNV12adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNV24adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNV36admsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNV36adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNV6adsA10V5 { get { throw null; } }
        public static Azure.ResourceManager.Discovery.Models.VmSize StandardNV72adsA10V5 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Discovery.Models.VmSize other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Discovery.Models.VmSize left, Azure.ResourceManager.Discovery.Models.VmSize right) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.VmSize (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Discovery.Models.VmSize? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Discovery.Models.VmSize left, Azure.ResourceManager.Discovery.Models.VmSize right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.WorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.WorkspaceProperties>
    {
        public WorkspaceProperties(Azure.ResourceManager.Discovery.Models.Identity workspaceIdentity) { }
        public Azure.Core.ResourceIdentifier AgentSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.CustomerManagedKeys? CustomerManagedKeys { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsClusterId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.MoboBrokerResource> ManagedOnBehalfOfMoboBrokerResources { get { throw null; } }
        public string ManagedResourceGroup { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Discovery.Models.DiscoveryPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointSubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.Discovery.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SupercomputerIds { get { throw null; } }
        public System.Uri WorkspaceApiUri { get { throw null; } }
        public Azure.ResourceManager.Discovery.Models.Identity WorkspaceIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier WorkspaceSubnetId { get { throw null; } set { } }
        public System.Uri WorkspaceUiUri { get { throw null; } }
        protected virtual Azure.ResourceManager.Discovery.Models.WorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Discovery.Models.WorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Discovery.Models.WorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.WorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Discovery.Models.WorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Discovery.Models.WorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.WorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.WorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Discovery.Models.WorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
