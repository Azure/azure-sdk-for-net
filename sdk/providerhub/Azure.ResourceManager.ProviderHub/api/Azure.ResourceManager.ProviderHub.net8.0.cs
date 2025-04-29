namespace Azure.ResourceManager.ProviderHub
{
    public partial class AzureResourceManagerProviderHubContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerProviderHubContext() { }
        public static Azure.ResourceManager.ProviderHub.AzureResourceManagerProviderHubContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CustomRolloutCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>, System.Collections.IEnumerable
    {
        protected CustomRolloutCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource> Get(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.CustomRolloutResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.CustomRolloutResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.CustomRolloutResource> GetIfExists(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetIfExistsAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.CustomRolloutResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.CustomRolloutResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.CustomRolloutResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CustomRolloutData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>
    {
        public CustomRolloutData(Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties properties) { }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.CustomRolloutData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.CustomRolloutData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomRolloutResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CustomRolloutResource() { }
        public virtual Azure.ResourceManager.ProviderHub.CustomRolloutData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string rolloutName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.CustomRolloutData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.CustomRolloutData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.CustomRolloutData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.CustomRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultRolloutCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>, System.Collections.IEnumerable
    {
        protected DefaultRolloutCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string rolloutName, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> Get(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> GetAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> GetIfExists(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> GetIfExistsAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DefaultRolloutData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>
    {
        public DefaultRolloutData() { }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.DefaultRolloutData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.DefaultRolloutData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultRolloutResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DefaultRolloutResource() { }
        public virtual Azure.ResourceManager.ProviderHub.DefaultRolloutData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string rolloutName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.DefaultRolloutData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.DefaultRolloutData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.DefaultRolloutData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedResourceTypeFirstSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>, System.Collections.IEnumerable
    {
        protected NestedResourceTypeFirstSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> GetIfExists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> GetIfExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NestedResourceTypeFirstSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NestedResourceTypeFirstSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string nestedResourceTypeFirst, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedResourceTypeSecondSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>, System.Collections.IEnumerable
    {
        protected NestedResourceTypeSecondSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> GetIfExists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> GetIfExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NestedResourceTypeSecondSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NestedResourceTypeSecondSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string nestedResourceTypeFirst, string nestedResourceTypeSecond, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NestedResourceTypeThirdSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>, System.Collections.IEnumerable
    {
        protected NestedResourceTypeThirdSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> GetIfExists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> GetIfExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NestedResourceTypeThirdSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NestedResourceTypeThirdSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NotificationRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>, System.Collections.IEnumerable
    {
        protected NotificationRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string notificationRegistrationName, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string notificationRegistrationName, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> Get(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> GetAsync(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> GetIfExists(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> GetIfExistsAsync(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NotificationRegistrationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>
    {
        public NotificationRegistrationData() { }
        public Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.NotificationRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.NotificationRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NotificationRegistrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NotificationRegistrationResource() { }
        public virtual Azure.ResourceManager.ProviderHub.NotificationRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string notificationRegistrationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.NotificationRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.NotificationRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.NotificationRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.NotificationRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ProviderHubExtensions
    {
        public static Azure.ResourceManager.ProviderHub.CustomRolloutResource GetCustomRolloutResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.DefaultRolloutResource GetDefaultRolloutResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource GetNestedResourceTypeFirstSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource GetNestedResourceTypeSecondSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource GetNestedResourceTypeThirdSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NotificationRegistrationResource GetNotificationRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetProviderRegistration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetProviderRegistrationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationResource GetProviderRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationCollection GetProviderRegistrations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource GetResourceTypeRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource GetResourceTypeSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ProviderRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>, System.Collections.IEnumerable
    {
        protected ProviderRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerNamespace, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerNamespace, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> Get(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetAsync(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetIfExists(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetIfExistsAsync(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderRegistrationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>
    {
        public ProviderRegistrationData() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderRegistrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderRegistrationResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ProviderRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo> CheckinManifest(Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>> CheckinManifestAsync(Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest> GenerateManifest(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>> GenerateManifestAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource> GetCustomRollout(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetCustomRolloutAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.CustomRolloutCollection GetCustomRollouts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource> GetDefaultRollout(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.DefaultRolloutResource>> GetDefaultRolloutAsync(string rolloutName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.DefaultRolloutCollection GetDefaultRollouts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource> GetNotificationRegistration(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NotificationRegistrationResource>> GetNotificationRegistrationAsync(string notificationRegistrationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NotificationRegistrationCollection GetNotificationRegistrations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> GetResourceTypeRegistration(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> GetResourceTypeRegistrationAsync(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationCollection GetResourceTypeRegistrations() { throw null; }
        Azure.ResourceManager.ProviderHub.ProviderRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ProviderRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceTypeRegistrationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>, System.Collections.IEnumerable
    {
        protected ResourceTypeRegistrationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceType, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceType, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> Get(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> GetAsync(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> GetIfExists(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> GetIfExistsAsync(string resourceType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceTypeRegistrationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>
    {
        public ResourceTypeRegistrationData() { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeRegistrationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceTypeRegistrationResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource> GetNestedResourceTypeFirstSku(string nestedResourceTypeFirst, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource>> GetNestedResourceTypeFirstSkuAsync(string nestedResourceTypeFirst, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuCollection GetNestedResourceTypeFirstSkus(string nestedResourceTypeFirst) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource> GetNestedResourceTypeSecondSku(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource>> GetNestedResourceTypeSecondSkuAsync(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuCollection GetNestedResourceTypeSecondSkus(string nestedResourceTypeFirst, string nestedResourceTypeSecond) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource> GetNestedResourceTypeThirdSku(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource>> GetNestedResourceTypeThirdSkuAsync(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird, string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuCollection GetNestedResourceTypeThirdSkus(string nestedResourceTypeFirst, string nestedResourceTypeSecond, string nestedResourceTypeThird) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> GetResourceTypeSku(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> GetResourceTypeSkuAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuCollection GetResourceTypeSkus() { throw null; }
        Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceTypeSkuCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>, System.Collections.IEnumerable
    {
        protected ResourceTypeSkuCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sku, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> Get(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> GetAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> GetIfExists(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> GetIfExistsAsync(string sku, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceTypeSkuData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>
    {
        public ResourceTypeSkuData() { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeSkuResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceTypeSkuResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string resourceType, string sku) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ResourceTypeSkuData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ResourceTypeSkuData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ResourceTypeSkuData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ProviderHub.Mocking
{
    public partial class MockableProviderHubArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableProviderHubArmClient() { }
        public virtual Azure.ResourceManager.ProviderHub.CustomRolloutResource GetCustomRolloutResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.DefaultRolloutResource GetDefaultRolloutResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource GetNestedResourceTypeFirstSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource GetNestedResourceTypeSecondSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource GetNestedResourceTypeThirdSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.NotificationRegistrationResource GetNotificationRegistrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ProviderRegistrationResource GetProviderRegistrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource GetResourceTypeRegistrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource GetResourceTypeSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableProviderHubSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProviderHubSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetProviderRegistration(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetProviderRegistrationAsync(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ProviderRegistrationCollection GetProviderRegistrations() { throw null; }
    }
}
namespace Azure.ResourceManager.ProviderHub.Models
{
    public static partial class ArmProviderHubModelFactory
    {
        public static Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo CheckinManifestInfo(bool isCheckedIn = false, string statusMessage = null, string pullRequest = null, string commitId = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.CustomRolloutData CustomRolloutData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.DefaultRolloutData DefaultRolloutData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule LinkedOperationRule(Azure.ResourceManager.ProviderHub.Models.LinkedOperation linkedOperation = default(Azure.ResourceManager.ProviderHub.Models.LinkedOperation), Azure.ResourceManager.ProviderHub.Models.LinkedAction linkedAction = default(Azure.ResourceManager.ProviderHub.Models.LinkedAction)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NotificationRegistrationData NotificationRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationData ProviderRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderResourceType ProviderResourceType(string name = null, Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType? routingType = default(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType?), Azure.ResourceManager.ProviderHub.Models.ResourceValidation? resourceValidation = default(Azure.ResourceManager.ProviderHub.Models.ResourceValidation?), System.Collections.Generic.IEnumerable<string> allowedUnauthorizedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> authorizationActionMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> linkedAccessChecks = null, string defaultApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LoggingRule> loggingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> throttlingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> endpoints = null, Azure.ResourceManager.ProviderHub.Models.MarketplaceType? marketplaceType = default(Azure.ResourceManager.ProviderHub.Models.MarketplaceType?), Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? managementType = default(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType?), System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule> subscriptionStateRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> serviceTreeInfos = null, Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? optInHeaders = default(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType?), string skuLink = null, System.Collections.Generic.IEnumerable<string> disallowedActionVerbs = null, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy templateDeploymentPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> extendedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> linkedOperationRules = null, Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy? resourceDeletionPolicy = default(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata ReRegisterSubscriptionMetadata(bool isEnabled = false, int? concurrencyLimit = default(int?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint ResourceProviderEndpoint(bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Uri endpointUri = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), System.TimeSpan? timeout = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest ResourceProviderManifest(System.Collections.Generic.IEnumerable<string> providerAuthenticationAllowedAudiences = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> providerAuthorizations = null, string @namespace = null, string providerVersion = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? providerType = default(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType?), System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? optInHeaders = default(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType> resourceTypes = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement management = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> capabilities = null, System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> globalNotificationEndpoints = null, Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata reRegisterSubscriptionMetadata = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData ResourceTypeRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeSkuData ResourceTypeSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy TemplateDeploymentPolicy(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability capabilities = default(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability), Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption preflightOptions = default(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo TypedErrorInfo(string typedErrorInfoType = null, System.BinaryData info = null) { throw null; }
    }
    public partial class AuthorizationActionMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping>
    {
        public AuthorizationActionMapping() { }
        public string Desired { get { throw null; } set { } }
        public string Original { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CanaryTrafficRegionRolloutConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration>
    {
        public CanaryTrafficRegionRolloutConfiguration() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Regions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> SkipRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckinManifestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent>
    {
        public CheckinManifestContent(string environment, Azure.Core.AzureLocation baselineArmManifestLocation) { }
        public Azure.Core.AzureLocation BaselineArmManifestLocation { get { throw null; } }
        public string Environment { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckinManifestInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>
    {
        internal CheckinManifestInfo() { }
        public string CommitId { get { throw null; } }
        public bool IsCheckedIn { get { throw null; } }
        public string PullRequest { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CheckNameAvailabilitySpecifications : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications>
    {
        public CheckNameAvailabilitySpecifications() { }
        public bool? IsDefaultValidationEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceTypesWithCustomValidation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomRolloutProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties>
    {
        public CustomRolloutProperties(Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification specification) { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification Specification { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomRolloutSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification>
    {
        public CustomRolloutSpecification(Azure.ResourceManager.ProviderHub.Models.TrafficRegions canary) { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> CanaryRegions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.ProviderRegistrationData ProviderRegistration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData> ResourceTypeRegistrations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomRolloutStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>
    {
        public CustomRolloutStatus() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> CompletedRegions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo> FailedOrSkippedRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultRolloutProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties>
    {
        public DefaultRolloutProperties() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification Specification { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultRolloutSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification>
    {
        public DefaultRolloutSpecification() { }
        public Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration Canary { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration HighTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration LowTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration MediumTraffic { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.ProviderRegistrationData ProviderRegistration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData> ResourceTypeRegistrations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration RestOfTheWorldGroupOne { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration RestOfTheWorldGroupTwo { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultRolloutStatus : Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus>
    {
        public DefaultRolloutStatus() { }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory? NextTrafficRegion { get { throw null; } set { } }
        public System.DateTimeOffset? NextTrafficRegionScheduledOn { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult? SubscriptionReregistrationResult { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtendedErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo>
    {
        public ExtendedErrorInfo() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo> Details { get { throw null; } }
        public string Message { get { throw null; } set { } }
        public string Target { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExtensionOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExtensionOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtensionOptions>
    {
        public ExtensionOptions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType> Request { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType> Response { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ExtensionOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExtensionOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExtensionOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ExtensionOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtensionOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtensionOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExtensionOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtensionOptionType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtensionOptionType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType DoNotMergeExistingReadOnlyAndSecretProperties { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType IncludeInternalMetadata { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType left, Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType left, Azure.ResourceManager.ProviderHub.Models.ExtensionOptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FeaturesPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FeaturesPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy All { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy Any { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy left, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy left, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityManagementProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>
    {
        public IdentityManagementProperties() { }
        public string ApplicationId { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? ManagementType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityManagementType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.IdentityManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityManagementType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType Actor { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType DelegatedResourceIdentity { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.IdentityManagementType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType left, Azure.ResourceManager.ProviderHub.Models.IdentityManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.IdentityManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType left, Azure.ResourceManager.ProviderHub.Models.IdentityManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LightHouseAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization>
    {
        public LightHouseAuthorization(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LinkedAccessCheck : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck>
    {
        public LinkedAccessCheck() { }
        public string ActionName { get { throw null; } set { } }
        public string LinkedAction { get { throw null; } set { } }
        public string LinkedActionVerb { get { throw null; } set { } }
        public string LinkedProperty { get { throw null; } set { } }
        public string LinkedType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedAction : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LinkedAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkedAction(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction Blocked { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction Enabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedAction Validate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LinkedAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LinkedAction left, Azure.ResourceManager.ProviderHub.Models.LinkedAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LinkedAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LinkedAction left, Azure.ResourceManager.ProviderHub.Models.LinkedAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LinkedOperation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LinkedOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LinkedOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperation CrossResourceGroupResourceMove { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperation CrossSubscriptionResourceMove { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperation None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LinkedOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LinkedOperation left, Azure.ResourceManager.ProviderHub.Models.LinkedOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LinkedOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LinkedOperation left, Azure.ResourceManager.ProviderHub.Models.LinkedOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LinkedOperationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule>
    {
        internal LinkedOperationRule() { }
        public Azure.ResourceManager.ProviderHub.Models.LinkedAction LinkedAction { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.LinkedOperation LinkedOperation { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoggingDetail : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LoggingDetail>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoggingDetail(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDetail Body { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDetail None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LoggingDetail other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LoggingDetail left, Azure.ResourceManager.ProviderHub.Models.LoggingDetail right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LoggingDetail (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LoggingDetail left, Azure.ResourceManager.ProviderHub.Models.LoggingDetail right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LoggingDirection : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.LoggingDirection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LoggingDirection(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDirection None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDirection Request { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.LoggingDirection Response { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.LoggingDirection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.LoggingDirection left, Azure.ResourceManager.ProviderHub.Models.LoggingDirection right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.LoggingDirection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.LoggingDirection left, Azure.ResourceManager.ProviderHub.Models.LoggingDirection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LoggingHiddenPropertyPaths : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths>
    {
        public LoggingHiddenPropertyPaths() { }
        public System.Collections.Generic.IList<string> HiddenPathsOnRequest { get { throw null; } }
        public System.Collections.Generic.IList<string> HiddenPathsOnResponse { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LoggingRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LoggingRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingRule>
    {
        public LoggingRule(string action, Azure.ResourceManager.ProviderHub.Models.LoggingDirection direction, Azure.ResourceManager.ProviderHub.Models.LoggingDetail detailLevel) { }
        public string Action { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.LoggingDetail DetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.LoggingDirection Direction { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.LoggingHiddenPropertyPaths HiddenPropertyPaths { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LoggingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LoggingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LoggingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LoggingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LoggingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManifestResourceDeletionPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManifestResourceDeletionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy Cascade { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy Force { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum MarketplaceType
    {
        NotSpecified = 0,
        AddOn = 1,
        Bypass = 2,
        Store = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageScope : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.MessageScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageScope(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.MessageScope NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.MessageScope RegisteredSubscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.MessageScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.MessageScope left, Azure.ResourceManager.ProviderHub.Models.MessageScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.MessageScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.MessageScope left, Azure.ResourceManager.ProviderHub.Models.MessageScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint>
    {
        public NotificationEndpoint() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public Azure.Core.ResourceIdentifier NotificationDestination { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NotificationMode : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.NotificationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NotificationMode(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.NotificationMode EventHub { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.NotificationMode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.NotificationMode WebHook { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.NotificationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.NotificationMode left, Azure.ResourceManager.ProviderHub.Models.NotificationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.NotificationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.NotificationMode left, Azure.ResourceManager.ProviderHub.Models.NotificationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NotificationRegistrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties>
    {
        public NotificationRegistrationProperties() { }
        public System.Collections.Generic.IList<string> IncludedEvents { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.MessageScope? MessageScope { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint> NotificationEndpoints { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.NotificationMode? NotificationMode { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OptInHeaderType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.OptInHeaderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptInHeaderType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType ClientGroupMembership { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType SignedAuxiliaryTokens { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType SignedUserToken { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType UnboundedClientGroupMembership { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType left, Azure.ResourceManager.ProviderHub.Models.OptInHeaderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.OptInHeaderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType left, Azure.ResourceManager.ProviderHub.Models.OptInHeaderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PreflightOption : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.PreflightOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PreflightOption(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.PreflightOption ContinueDeploymentOnFailure { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.PreflightOption DefaultValidationOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.PreflightOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.PreflightOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.PreflightOption left, Azure.ResourceManager.ProviderHub.Models.PreflightOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.PreflightOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.PreflightOption left, Azure.ResourceManager.ProviderHub.Models.PreflightOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderHubExtendedLocationOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>
    {
        public ProviderHubExtendedLocationOptions() { }
        public string ExtendedLocationOptionsType { get { throw null; } set { } }
        public string SupportedPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ProviderHubExtendedLocationType
    {
        NotSpecified = 0,
        EdgeZone = 1,
        ArcZone = 2,
    }
    public partial class ProviderHubMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>
    {
        public ProviderHubMetadata() { }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization ThirdPartyProviderAuthorization { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderHubProvisioningState : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderHubProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState MovingResources { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState RolloutInProgress { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState TransientFailure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState left, Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState left, Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderRegistrationProperties : Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>
    {
        public ProviderRegistrationProperties() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata ProviderHubMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecifications { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>
    {
        internal ProviderResourceType() { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedUnauthorizedActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> AuthorizationActionMappings { get { throw null; } }
        public string DefaultApiVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DisallowedActionVerbs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> ExtendedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> LinkedAccessChecks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> LinkedOperationRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LoggingRule> LoggingRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? ManagementType { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.MarketplaceType? MarketplaceType { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy? ResourceDeletionPolicy { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceValidation? ResourceValidation { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType? RoutingType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> ServiceTreeInfos { get { throw null; } }
        public string SkuLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule> SubscriptionStateRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy TemplateDeploymentPolicy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> ThrottlingRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderResourceType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderResourceType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderSubscriptionState : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderSubscriptionState(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState Enabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState NotDefined { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState PastDue { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState Warned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState left, Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState left, Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderSubscriptionStateRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule>
    {
        public ProviderSubscriptionStateRule() { }
        public System.Collections.Generic.IList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReRegisterSubscriptionMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata>
    {
        internal ReRegisterSubscriptionMetadata() { }
        public int? ConcurrencyLimit { get { throw null; } }
        public bool IsEnabled { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceAccessPolicy
    {
        NotSpecified = 0,
        AcisReadAllowed = 1,
        AcisActionAllowed = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceDeletionPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceDeletionPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy CascadeDeleteAll { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy CascadeDeleteProxyOnlyChildren { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceMovePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy>
    {
        public ResourceMovePolicy() { }
        public bool? IsCrossResourceGroupMoveEnabled { get { throw null; } set { } }
        public bool? IsCrossSubscriptionMoveEnabled { get { throw null; } set { } }
        public bool? IsValidationRequired { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization>
    {
        public ResourceProviderAuthorization() { }
        public string ApplicationId { get { throw null; } set { } }
        public string ManagedByRoleDefinitionId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities>
    {
        public ResourceProviderCapabilities(string quotaId, Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect effect) { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect Effect { get { throw null; } set { } }
        public string QuotaId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProviderCapabilitiesEffect : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProviderCapabilitiesEffect(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect Allow { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect Disallow { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilitiesEffect right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProviderEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>
    {
        internal ResourceProviderEndpoint() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Uri EndpointUri { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderManagement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>
    {
        public ResourceProviderManagement() { }
        public string IncidentContactEmail { get { throw null; } set { } }
        public string IncidentRoutingService { get { throw null; } set { } }
        public string IncidentRoutingTeam { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManifestOwners { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceAccessPolicy? ResourceAccessPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> ResourceAccessRoles { get { throw null; } }
        public System.Collections.Generic.IList<string> SchemaOwners { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> ServiceTreeInfos { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderManifest : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>
    {
        internal ResourceProviderManifest() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> GlobalNotificationEndpoints { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement Management { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? ProviderType { get { throw null; } }
        public string ProviderVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata ReRegisterSubscriptionMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderManifestProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>
    {
        public ResourceProviderManifestProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement Management { get { throw null; } set { } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? ProviderType { get { throw null; } set { } }
        public string ProviderVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions TemplateDeploymentOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProviderType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProviderType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType AuthorizationFree { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType External { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType Hidden { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType Internal { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType LegacyRegistrationRequired { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType RegistrationFree { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderType TenantOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceProviderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceRoutingType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceRoutingType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType CascadeExtension { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Default { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Extension { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Failover { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Fanout { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType HostBased { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType LocationBased { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType ProxyOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Tenant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType left, Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType left, Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability>
    {
        public ResourceSkuCapability(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>
    {
        public ResourceTypeEndpoint() { }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension> Extensions { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension>
    {
        public ResourceTypeExtension() { }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory> ExtensionCategories { get { throw null; } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeExtensionCategory : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeExtensionCategory(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceCreationBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceCreationCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceCreationValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceDeletionBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceDeletionCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceDeletionValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceMoveBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceMoveCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourcePatchBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourcePatchCompleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourcePatchValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourcePostAction { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceReadBegin { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory ResourceReadValidate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory SubscriptionLifecycleNotification { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeRegistrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>
    {
        public ResourceTypeRegistrationProperties() { }
        public System.Collections.Generic.IList<string> AllowedUnauthorizedActions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> AuthorizationActionMappings { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications CheckNameAvailabilitySpecifications { get { throw null; } set { } }
        public string DefaultApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisallowedActionVerbs { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ExtensionOptions ExtensionOptionsResourceCreationBegin { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties IdentityManagement { get { throw null; } set { } }
        public bool? IsAsyncOperationEnabled { get { throw null; } set { } }
        public bool? IsPureProxy { get { throw null; } set { } }
        public bool? IsThirdPartyS2SEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> LinkedAccessChecks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LoggingRule> LoggingRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.MarketplaceType? MarketplaceType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality? Regionality { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy? ResourceDeletionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy ResourceMovePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType? RoutingType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> ServiceTreeInfos { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule> SubscriptionStateRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification> SwaggerSpecifications { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions TemplateDeploymentOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> ThrottlingRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeRegistrationRegionality : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeRegistrationRegionality(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality Global { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality Regional { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity>
    {
        public ResourceTypeSkuCapacity(int minimum) { }
        public int? Default { get { throw null; } set { } }
        public int? Maximum { get { throw null; } set { } }
        public int Minimum { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType? ScaleType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeSkuCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost>
    {
        public ResourceTypeSkuCost(string meterId) { }
        public string ExtendedUnit { get { throw null; } set { } }
        public string MeterId { get { throw null; } set { } }
        public int? Quantity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo>
    {
        public ResourceTypeSkuLocationInfo(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<string> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeSkuProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties>
    {
        public ResourceTypeSkuProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting> skuSettings) { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting> SkuSettings { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeSkuScaleType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeSkuScaleType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType Automatic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType Manual { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuScaleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeSkuSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting>
    {
        public ResourceTypeSkuSetting(string name) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCapacity Capacity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuCost> Costs { get { throw null; } }
        public string Family { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredQuotaIds { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeSkuZoneDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail>
    {
        public ResourceTypeSkuZoneDetail() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceSkuCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IList<string> Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuZoneDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceValidation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceValidation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceValidation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceValidation NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceValidation ProfaneWords { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceValidation ReservedWords { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceValidation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceValidation left, Azure.ResourceManager.ProviderHub.Models.ResourceValidation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceValidation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceValidation left, Azure.ResourceManager.ProviderHub.Models.ResourceValidation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RolloutStatusBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase>
    {
        public RolloutStatusBase() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> CompletedRegions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ProviderHub.Models.ExtendedErrorInfo> FailedOrSkippedRegions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.RolloutStatusBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ServiceTreeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>
    {
        public ServiceTreeInfo() { }
        public string ComponentId { get { throw null; } set { } }
        public string ServiceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubscriptionLifecycleNotificationSpecifications : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications>
    {
        public SubscriptionLifecycleNotificationSpecifications() { }
        public System.TimeSpan? SoftDeleteTtl { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction> SubscriptionStateOverrideActions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionNotificationOperation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionNotificationOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation BillingCancellation { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation DeleteAllResources { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation NoOp { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation NotDefined { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation SoftDeleteAllResources { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation UndoSoftDelete { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation left, Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation left, Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionReregistrationResult : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionReregistrationResult(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult ConditionalUpdate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult Failed { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult ForcedUpdate { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult NotApplicable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult left, Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult left, Azure.ResourceManager.ProviderHub.Models.SubscriptionReregistrationResult right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionStateOverrideAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction>
    {
        public SubscriptionStateOverrideAction(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState state, Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation action) { }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionNotificationOperation Action { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriptionStateOverrideAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubscriptionTransitioningState : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubscriptionTransitioningState(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Registered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Suspended { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToDeleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToRegistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToUnregistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState SuspendedToWarned { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Unregistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState Warned { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToDeleted { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToRegistered { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToSuspended { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState WarnedToUnregistered { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState left, Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState left, Azure.ResourceManager.ProviderHub.Models.SubscriptionTransitioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SwaggerSpecification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification>
    {
        public SwaggerSpecification() { }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public System.Uri SwaggerSpecFolderUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateDeploymentCapability : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateDeploymentCapability(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability Default { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability Preflight { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemplateDeploymentOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions>
    {
        public TemplateDeploymentOptions() { }
        public bool? IsPreflightSupported { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.PreflightOption> PreflightOptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateDeploymentPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>
    {
        internal TemplateDeploymentPolicy() { }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption PreflightOptions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateDeploymentPreflightOption : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateDeploymentPreflightOption(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption DeploymentRequests { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption RegisteredOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption TestOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption ValidationRequests { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThirdPartyProviderAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization>
    {
        public ThirdPartyProviderAuthorization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LightHouseAuthorization> Authorizations { get { throw null; } }
        public string ManagedByTenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyProviderAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThrottlingMetric : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric>
    {
        public ThrottlingMetric(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType metricType, long limit) { }
        public System.TimeSpan? Interval { get { throw null; } set { } }
        public long Limit { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType MetricType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThrottlingMetricType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThrottlingMetricType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType NumberOfRequests { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType NumberOfResources { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType left, Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType left, Azure.ResourceManager.ProviderHub.Models.ThrottlingMetricType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThrottlingRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>
    {
        public ThrottlingRule(string action, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric> metrics) { }
        public string Action { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric> Metrics { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThrottlingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThrottlingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TrafficRegionCategory : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TrafficRegionCategory(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory Canary { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory HighTraffic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory LowTraffic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory MediumTraffic { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory RestOfTheWorldGroupOne { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory RestOfTheWorldGroupTwo { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory left, Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory left, Azure.ResourceManager.ProviderHub.Models.TrafficRegionCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TrafficRegionRolloutConfiguration : Azure.ResourceManager.ProviderHub.Models.TrafficRegions, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration>
    {
        public TrafficRegionRolloutConfiguration() { }
        public System.TimeSpan? WaitDuration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TrafficRegions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegions>
    {
        public TrafficRegions() { }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Regions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TrafficRegions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TrafficRegions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TrafficRegions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TypedErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo>
    {
        public TypedErrorInfo(string typedErrorInfoType) { }
        public System.BinaryData Info { get { throw null; } }
        public string TypedErrorInfoType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
