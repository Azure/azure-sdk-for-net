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
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.CustomRolloutResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ProviderAuthorizedApplicationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>, System.Collections.IEnumerable
    {
        protected ProviderAuthorizedApplicationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, System.Guid applicationId, Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, System.Guid applicationId, Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> Get(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>> GetAsync(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> GetIfExists(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>> GetIfExistsAsync(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderAuthorizedApplicationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>
    {
        public ProviderAuthorizedApplicationData() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderAuthorizedApplicationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderAuthorizedApplicationResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, System.Guid applicationId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ProviderHubExtensions
    {
        public static Azure.ResourceManager.ProviderHub.CustomRolloutResource GetCustomRolloutResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.DefaultRolloutResource GetDefaultRolloutResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeFirstSkuResource GetNestedResourceTypeFirstSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeSecondSkuResource GetNestedResourceTypeSecondSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NestedResourceTypeThirdSkuResource GetNestedResourceTypeThirdSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NotificationRegistrationResource GetNotificationRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource GetProviderAuthorizedApplicationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetProviderMonitorSetting(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>> GetProviderMonitorSettingAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource GetProviderMonitorSettingResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderMonitorSettingCollection GetProviderMonitorSettings(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetProviderMonitorSettings(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetProviderMonitorSettingsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetProviderRegistration(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetProviderRegistrationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationResource GetProviderRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationCollection GetProviderRegistrations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource GetRegistrationNewRegionFrontloadReleaseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource GetResourceTypeRegistrationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource GetResourceTypeSkuResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class ProviderMonitorSettingCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>, System.Collections.IEnumerable
    {
        protected ProviderMonitorSettingCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string providerMonitorSettingName, Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string providerMonitorSettingName, Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> Get(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>> GetAsync(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetIfExists(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>> GetIfExistsAsync(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ProviderMonitorSettingData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>
    {
        public ProviderMonitorSettingData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProviderMonitorSettingProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderMonitorSettingResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ProviderMonitorSettingResource() { }
        public virtual Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerMonitorSettingName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> Update(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>> UpdateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind? Kind { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation DeleteResourcesResourceAction(Azure.WaitUntil waitUntil, string resourceActionName, Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteResourcesResourceActionAsync(Azure.WaitUntil waitUntil, string resourceActionName, Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest> GenerateManifest(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>> GenerateManifestAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest> GenerateManifestNewRegionFrontloadRelease(Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest>> GenerateManifestNewRegionFrontloadReleaseAsync(Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource> GetProviderAuthorizedApplication(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource>> GetProviderAuthorizedApplicationAsync(System.Guid applicationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationCollection GetProviderAuthorizedApplications() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource> GetRegistrationNewRegionFrontloadRelease(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource>> GetRegistrationNewRegionFrontloadReleaseAsync(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseCollection GetRegistrationNewRegionFrontloadReleases() { throw null; }
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
    public partial class RegistrationNewRegionFrontloadReleaseCollection : Azure.ResourceManager.ArmCollection
    {
        protected RegistrationNewRegionFrontloadReleaseCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string releaseName, Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string releaseName, Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource> Get(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource>> GetAsync(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource> GetIfExists(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource>> GetIfExistsAsync(string releaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegistrationNewRegionFrontloadReleaseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegistrationNewRegionFrontloadReleaseResource() { }
        public virtual Azure.ResourceManager.ProviderHub.DefaultRolloutData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string providerNamespace, string releaseName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Stop(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.ProviderHub.DefaultRolloutData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.DefaultRolloutData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.DefaultRolloutData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind? Kind { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationResource GetProviderAuthorizedApplicationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource GetProviderMonitorSettingResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ProviderRegistrationResource GetProviderRegistrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.RegistrationNewRegionFrontloadReleaseResource GetRegistrationNewRegionFrontloadReleaseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationResource GetResourceTypeRegistrationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ResourceTypeSkuResource GetResourceTypeSkuResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableProviderHubResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProviderHubResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetProviderMonitorSetting(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource>> GetProviderMonitorSettingAsync(string providerMonitorSettingName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ProviderMonitorSettingCollection GetProviderMonitorSettings() { throw null; }
    }
    public partial class MockableProviderHubSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableProviderHubSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetProviderMonitorSettings(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ProviderHub.ProviderMonitorSettingResource> GetProviderMonitorSettingsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource> GetProviderRegistration(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ProviderHub.ProviderRegistrationResource>> GetProviderRegistrationAsync(string providerNamespace, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ProviderHub.ProviderRegistrationCollection GetProviderRegistrations() { throw null; }
    }
}
namespace Azure.ResourceManager.ProviderHub.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalOptionAsyncOperation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalOptionAsyncOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation ProtectedAsyncOperationPolling { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation ProtectedAsyncOperationPollingAuditOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation left, Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation left, Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalOptionResourceType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalOptionResourceType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType ProtectedAsyncOperationPolling { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType ProtectedAsyncOperationPollingAuditOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType left, Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType left, Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AdditionalOptionResourceTypeRegistration : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AdditionalOptionResourceTypeRegistration(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration ProtectedAsyncOperationPolling { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration ProtectedAsyncOperationPollingAuditOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration left, Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration left, Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AllowedResourceName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName>
    {
        public AllowedResourceName() { }
        public string GetActionVerb { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AllowedResourceName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AllowedResourceName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AllowedUnauthorizedActionIntent : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AllowedUnauthorizedActionIntent(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent DeferredAccessCheck { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent LowPrivilege { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent RPContract { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent left, Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent left, Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AllowedUnauthorizedActionsExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension>
    {
        public AllowedUnauthorizedActionsExtension() { }
        public string Action { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionIntent? Intent { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplicationDataAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization>
    {
        public ApplicationDataAuthorization(Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole role) { }
        public System.Collections.Generic.IList<string> ResourceTypes { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole Role { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ApplicationOwnershipRole : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ApplicationOwnershipRole(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole LimitedOwner { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole ServiceOwner { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole left, Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole left, Azure.ResourceManager.ProviderHub.Models.ApplicationOwnershipRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationProviderAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization>
    {
        public ApplicationProviderAuthorization() { }
        public string ManagedByRoleDefinitionId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmProviderHubModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo CheckinManifestInfo(bool isCheckedIn = false, string statusMessage = null, string pullRequest = null, string commitId = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.CustomRolloutData CustomRolloutData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.CustomRolloutProperties CustomRolloutProperties(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? provisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?), Azure.ResourceManager.ProviderHub.Models.CustomRolloutSpecification specification = null, Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus status = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.DefaultRolloutData DefaultRolloutData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.DefaultRolloutProperties DefaultRolloutProperties(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? provisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?), Azure.ResourceManager.ProviderHub.Models.DefaultRolloutSpecification specification = null, Azure.ResourceManager.ProviderHub.Models.DefaultRolloutStatus status = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule LinkedOperationRule(Azure.ResourceManager.ProviderHub.Models.LinkedOperation linkedOperation = default(Azure.ResourceManager.ProviderHub.Models.LinkedOperation), Azure.ResourceManager.ProviderHub.Models.LinkedAction linkedAction = default(Azure.ResourceManager.ProviderHub.Models.LinkedAction)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.NotificationRegistrationData NotificationRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.NotificationRegistrationProperties NotificationRegistrationProperties(Azure.ResourceManager.ProviderHub.Models.NotificationMode? notificationMode = default(Azure.ResourceManager.ProviderHub.Models.NotificationMode?), Azure.ResourceManager.ProviderHub.Models.MessageScope? messageScope = default(Azure.ResourceManager.ProviderHub.Models.MessageScope?), System.Collections.Generic.IEnumerable<string> includedEvents = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.NotificationEndpoint> notificationEndpoints = null, Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? provisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderAuthorizedApplicationData ProviderAuthorizedApplicationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties ProviderAuthorizedApplicationProperties(Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization providerAuthorization = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization> dataAuthorizations = null, Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? provisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderMonitorSettingData ProviderMonitorSettingData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? providerMonitorSettingProvisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationData ProviderRegistrationData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties properties) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ProviderRegistrationData ProviderRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties properties = null, Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind? kind = default(Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties ProviderRegistrationProperties(System.Collections.Generic.IEnumerable<string> providerAuthenticationAllowedAudiences = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> providerAuthorizations = null, string @namespace = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService> services = null, string serviceName = null, string providerVersion = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? providerType = default(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType?), System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions requestHeaderOptions = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement management = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> capabilities = null, Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? crossTenantTokenValidation = default(Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation?), System.BinaryData metadata = null, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions templateDeploymentOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> globalNotificationEndpoints = null, bool? enableTenantLinkedNotification = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> notifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule> linkedNotificationRules = null, Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules asyncOperationPollingRules = null, Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration dstsConfiguration = null, Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption? notificationOptions = default(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount> resourceHydrationAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting> notificationSubscriberSettings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> managementGroupGlobalNotificationEndpoints = null, System.Collections.Generic.IEnumerable<string> optionalFeatures = null, Azure.ResourceManager.ProviderHub.Models.BlockActionVerb? resourceGroupLockOptionDuringMoveBlockActionVerb = default(Azure.ResourceManager.ProviderHub.Models.BlockActionVerb?), Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType? serviceClientOptionsType = default(Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType?), string legacyNamespace = null, System.Collections.Generic.IEnumerable<string> legacyRegistrations = null, string customManifestVersion = null, Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata providerHubMetadata = null, Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? provisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?), Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications subscriptionLifecycleNotificationSpecifications = null, System.Collections.Generic.IEnumerable<string> privateResourceProviderAllowedSubscriptions = null, Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration tokenAuthConfiguration = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderResourceType ProviderResourceType(string name = null, Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType? routingType = default(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType?), Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType? additionalOptions = default(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType?), Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? crossTenantTokenValidation = default(Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation?), Azure.ResourceManager.ProviderHub.Models.ResourceValidation? resourceValidation = default(Azure.ResourceManager.ProviderHub.Models.ResourceValidation?), System.Collections.Generic.IEnumerable<string> allowedUnauthorizedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension> allowedUnauthorizedActionsExtensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> authorizationActionMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> linkedAccessChecks = null, string defaultApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LoggingRule> loggingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> throttlingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> endpoints = null, Azure.ResourceManager.ProviderHub.Models.MarketplaceType? marketplaceType = default(Azure.ResourceManager.ProviderHub.Models.MarketplaceType?), Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? managementType = default(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType?), System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule> subscriptionStateRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> serviceTreeInfos = null, Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions requestHeaderOptions = null, string skuLink = null, System.Collections.Generic.IEnumerable<string> disallowedActionVerbs = null, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy templateDeploymentPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> extendedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> linkedOperationRules = null, Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy? resourceDeletionPolicy = default(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy?), Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule quotaRule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> notifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule> linkedNotificationRules = null, Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules asyncOperationPollingRules = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.Models.ProviderResourceType ProviderResourceType(string name = null, Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType? routingType = default(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType?), Azure.ResourceManager.ProviderHub.Models.ResourceValidation? resourceValidation = default(Azure.ResourceManager.ProviderHub.Models.ResourceValidation?), System.Collections.Generic.IEnumerable<string> allowedUnauthorizedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> authorizationActionMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> linkedAccessChecks = null, string defaultApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LoggingRule> loggingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> throttlingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> endpoints = null, Azure.ResourceManager.ProviderHub.Models.MarketplaceType? marketplaceType = default(Azure.ResourceManager.ProviderHub.Models.MarketplaceType?), Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? managementType = default(Azure.ResourceManager.ProviderHub.Models.IdentityManagementType?), System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule> subscriptionStateRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> serviceTreeInfos = null, Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? optInHeaders = default(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType?), string skuLink = null, System.Collections.Generic.IEnumerable<string> disallowedActionVerbs = null, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy templateDeploymentPolicy = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> extendedLocations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> linkedOperationRules = null, Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy? resourceDeletionPolicy = default(Azure.ResourceManager.ProviderHub.Models.ManifestResourceDeletionPolicy?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata ReRegisterSubscriptionMetadata(bool isEnabled = false, int? concurrencyLimit = default(int?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity ResourceManagementEntity(Azure.Core.ResourceIdentifier resourceId = null, string homeTenantId = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string status = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint ResourceProviderEndpoint(bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Uri endpointUri = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), System.TimeSpan? timeout = default(System.TimeSpan?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint ResourceProviderEndpoint(bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Uri endpointUri = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), System.TimeSpan? timeout = default(System.TimeSpan?), Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType? endpointType = default(Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType?), string skuLink = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest ResourceProviderManifest(System.Collections.Generic.IEnumerable<string> providerAuthenticationAllowedAudiences = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> providerAuthorizations = null, string @namespace = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService> services = null, string serviceName = null, string providerVersion = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? providerType = default(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType?), System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions requestHeaderOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType> resourceTypes = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement management = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> capabilities = null, Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? crossTenantTokenValidation = default(Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation?), System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> globalNotificationEndpoints = null, Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata reRegisterSubscriptionMetadata = null, bool? isTenantLinkedNotificationEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> notifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule> linkedNotificationRules = null, Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules asyncOperationPollingRules = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifest ResourceProviderManifest(System.Collections.Generic.IEnumerable<string> providerAuthenticationAllowedAudiences = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> providerAuthorizations = null, string @namespace = null, string providerVersion = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? providerType = default(Azure.ResourceManager.ProviderHub.Models.ResourceProviderType?), System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? optInHeaders = default(Azure.ResourceManager.ProviderHub.Models.OptInHeaderType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType> resourceTypes = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement management = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> capabilities = null, System.BinaryData metadata = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> globalNotificationEndpoints = null, Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata reRegisterSubscriptionMetadata = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData ResourceTypeRegistrationData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties properties) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData ResourceTypeRegistrationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties properties = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind? kind = default(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind?)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties ResourceTypeRegistrationProperties(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType? routingType = default(Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType?), Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration? additionalOptions = default(Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration?), Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? crossTenantTokenValidation = default(Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation?), Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality? regionality = default(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint> endpoints = null, Azure.ResourceManager.ProviderHub.Models.ExtensionOptions extensionOptionsResourceCreationBegin = null, Azure.ResourceManager.ProviderHub.Models.MarketplaceType? marketplaceType = default(Azure.ResourceManager.ProviderHub.Models.MarketplaceType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification> swaggerSpecifications = null, System.Collections.Generic.IEnumerable<string> allowedUnauthorizedActions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension> allowedUnauthorizedActionsExtensions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> authorizationActionMappings = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> linkedAccessChecks = null, string defaultApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LoggingRule> loggingRules = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> throttlingRules = null, System.Collections.Generic.IEnumerable<string> requiredFeatures = null, Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? requiredFeaturesPolicy = default(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy?), bool? isAsyncOperationEnabled = default(bool?), Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? provisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?), bool? isThirdPartyS2SEnabled = default(bool?), Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications subscriptionLifecycleNotificationSpecifications = null, bool? isPureProxy = default(bool?), Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties identityManagement = null, Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications checkNameAvailabilitySpecifications = null, System.Collections.Generic.IEnumerable<string> disallowedActionVerbs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> serviceTreeInfos = null, Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions requestHeaderOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule> subscriptionStateRules = null, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions templateDeploymentOptions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> extendedLocations = null, Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy resourceMovePolicy = null, Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy? resourceDeletionPolicy = default(Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption> resourceConcurrencyControlOptions = null, Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration resourceGraphConfiguration = null, Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement management = null, bool? isNoncompliantCollectionResponseAllowed = default(bool?), Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken onBehalfOfTokens = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory? category = default(Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory?), Azure.ResourceManager.ProviderHub.Models.ResourceValidation? resourceValidation = default(Azure.ResourceManager.ProviderHub.Models.ResourceValidation?), System.Collections.Generic.IEnumerable<string> disallowedEndUserOperations = null, System.Collections.Generic.IDictionary<string, System.BinaryData> metadata = null, string skuLink = null, Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule quotaRule = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> notifications = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule> linkedNotificationRules = null, Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules asyncOperationPollingRules = null, Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration tokenAuthConfiguration = null, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy templateDeploymentPolicy = null, bool? isEmptyRoleAssignmentsAllowed = default(bool?), Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType? policyExecutionType = default(Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType?), Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy? availabilityZonePolicy = default(Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy?), Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration dstsConfiguration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule> asyncTimeoutRules = null, System.Collections.Generic.IEnumerable<string> commonApiVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile> apiProfiles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> linkedOperationRules = null, string legacyName = null, System.Collections.Generic.IEnumerable<string> legacyNames = null, System.Collections.Generic.IEnumerable<string> allowedTemplateDeploymentReferenceActions = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy legacyPolicy = null, string manifestLink = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule capacityRule = null, bool? isAddOnPlanConversionAllowed = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName> allowedResourceNames = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache resourceCache = null, Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption? resourceQueryManagementFilterOption = default(Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption?), bool? areTagsSupported = default(bool?), Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions resourceManagementOptions = null, string groupingTag = null, bool? isAddResourceListTargetLocationsAllowed = default(bool?), Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode? commonApiVersionsMergeMode = default(Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode?), string routingRuleHostResourceType = null, Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode? frontdoorRequestMode = default(Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode?), Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType? resourceSubType = default(Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType?), string asyncOperationResourceTypeName = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.ResourceTypeSkuData ResourceTypeSkuData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuProperties ResourceTypeSkuProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeSkuSetting> skuSettings = null, Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? provisioningState = default(Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy TemplateDeploymentPolicy(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability capabilities = default(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability), Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption preflightOptions = default(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption)) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TypedErrorInfo TypedErrorInfo(string typedErrorInfoType = null, System.BinaryData info = null) { throw null; }
    }
    public partial class AsyncOperationPollingRules : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules>
    {
        public AsyncOperationPollingRules() { }
        public Azure.ResourceManager.ProviderHub.Models.AdditionalOptionAsyncOperation? AdditionalOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> AuthorizationActions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AsyncTimeoutRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule>
    {
        public AsyncTimeoutRule() { }
        public string ActionName { get { throw null; } set { } }
        public string Timeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailabilityZonePolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailabilityZonePolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy MultiZoned { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy SingleZoned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy left, Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy left, Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailableCheckInManifestEnvironment : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailableCheckInManifestEnvironment(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment All { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment Canary { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment Fairfax { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment Mooncake { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment Prod { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment left, Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment left, Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BlockActionVerb : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.BlockActionVerb>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BlockActionVerb(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.BlockActionVerb Action { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.BlockActionVerb Delete { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.BlockActionVerb NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.BlockActionVerb Read { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.BlockActionVerb Unrecognized { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.BlockActionVerb Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.BlockActionVerb other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.BlockActionVerb left, Azure.ResourceManager.ProviderHub.Models.BlockActionVerb right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.BlockActionVerb (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.BlockActionVerb left, Azure.ResourceManager.ProviderHub.Models.BlockActionVerb right) { throw null; }
        public override string ToString() { throw null; }
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
        public CheckinManifestInfo(bool isCheckedIn, string statusMessage) { }
        public string CommitId { get { throw null; } set { } }
        public bool IsCheckedIn { get { throw null; } set { } }
        public string PullRequest { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommonApiVersionsMergeMode : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommonApiVersionsMergeMode(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode Merge { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode left, Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode left, Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CrossTenantTokenValidation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CrossTenantTokenValidation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation EnsureSecureValidation { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation PassthroughInsecureToken { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation left, Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation left, Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CustomRolloutAutoProvisionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig>
    {
        public CustomRolloutAutoProvisionConfig() { }
        public bool? IsResourceGraphEnabled { get { throw null; } set { } }
        public bool? IsStorageEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public CustomRolloutSpecification() { }
        public CustomRolloutSpecification(Azure.ResourceManager.ProviderHub.Models.TrafficRegions canary) { }
        public Azure.ResourceManager.ProviderHub.Models.CustomRolloutAutoProvisionConfig AutoProvisionConfig { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> CanaryRegions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.ProviderRegistrationData ProviderRegistration { get { throw null; } set { } }
        public bool? RefreshSubscriptionRegistration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ReleaseScopes { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.ResourceTypeRegistrationData> ResourceTypeRegistrations { get { throw null; } }
        public bool? SkipReleaseScopeValidation { get { throw null; } set { } }
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
        public Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo ManifestCheckinStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.CustomRolloutStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultRolloutAutoProvisionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig>
    {
        public DefaultRolloutAutoProvisionConfig() { }
        public bool? IsResourceGraphEnabled { get { throw null; } set { } }
        public bool? IsStorageEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.ProviderHub.Models.DefaultRolloutAutoProvisionConfig AutoProvisionConfig { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.CanaryTrafficRegionRolloutConfiguration Canary { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TrafficRegionRolloutConfiguration HighTraffic { get { throw null; } set { } }
        public bool? IsExpeditedRolloutEnabled { get { throw null; } set { } }
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
        public Azure.ResourceManager.ProviderHub.Models.CheckinManifestInfo ManifestCheckinStatus { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExpeditedRolloutIntent : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExpeditedRolloutIntent(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent Hotfix { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent left, Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent left, Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExpeditedRolloutMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata>
    {
        public ExpeditedRolloutMetadata() { }
        public Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutIntent? ExpeditedRolloutIntent { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class FanoutLinkedNotificationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule>
    {
        public FanoutLinkedNotificationRule() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration DstsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> Endpoints { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration TokenAuthConfiguration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FrontdoorRequestMode : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FrontdoorRequestMode(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode UseManifest { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode left, Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode left, Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityManagementProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties>
    {
        public IdentityManagementProperties() { }
        public string ApplicationId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ApplicationIds { get { throw null; } }
        public System.Collections.Generic.IList<string> DelegationAppIds { get { throw null; } }
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
    public partial class LegacyDisallowedCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition>
    {
        public LegacyDisallowedCondition() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation> DisallowedLegacyOperations { get { throw null; } }
        public string Feature { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class LinkedNotificationRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule>
    {
        public LinkedNotificationRule() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IList<string> ActionsOnFailedOperation { get { throw null; } }
        public System.Collections.Generic.IList<string> FastPathActions { get { throw null; } }
        public System.Collections.Generic.IList<string> FastPathActionsOnFailedOperation { get { throw null; } }
        public System.TimeSpan? LinkedNotificationTimeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public LinkedOperationRule(Azure.ResourceManager.ProviderHub.Models.LinkedOperation linkedOperation, Azure.ResourceManager.ProviderHub.Models.LinkedAction linkedAction) { }
        public System.Collections.Generic.IList<string> DependsOnTypes { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.LinkedAction LinkedAction { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.LinkedOperation LinkedOperation { get { throw null; } set { } }
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
    public partial class ManifestLevelPropertyBag : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag>
    {
        public ManifestLevelPropertyBag() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount> ResourceHydrationAccounts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType ClientPrincipalNameEncoded { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType ManagementGroupAncestorsEncoded { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType MSIResourceIdEncoded { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType PrivateLinkId { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType PrivateLinkResourceId { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType PrivateLinkVnetTrafficTag { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptInHeaderType ResourceGroupLocation { get { throw null; } }
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
    public readonly partial struct OptOutHeaderType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OptOutHeaderType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType SystemDataCreatedByLastModifiedBy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType left, Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType left, Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PolicyExecutionType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PolicyExecutionType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType BypassPolicies { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType ExecutePolicies { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType ExpectPartialPutRequests { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType left, Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType left, Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType right) { throw null; }
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
    public partial class ProviderAdditionalAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization>
    {
        public ProviderAdditionalAuthorization() { }
        public string ApplicationId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderAuthenticationScheme : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderAuthenticationScheme(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme Bearer { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme PoP { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme left, Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme left, Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderAuthorizedApplicationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties>
    {
        public ProviderAuthorizedApplicationProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ApplicationDataAuthorization> DataAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ApplicationProviderAuthorization ProviderAuthorization { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderAuthorizedApplicationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderDstsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration>
    {
        public ProviderDstsConfiguration(string serviceName) { }
        public string ServiceDnsName { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderEndpointInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation>
    {
        public ProviderEndpointInformation() { }
        public string Endpoint { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType? EndpointType { get { throw null; } set { } }
        public string SchemaVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderEndpointType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType Canary { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType Production { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType TestInProduction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType left, Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType left, Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderEndpointTypeResourceType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderEndpointTypeResourceType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType Canary { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType Production { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType TestInProduction { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType left, Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType left, Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderExtendedLocationType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType ArcZone { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType CustomLocation { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType EdgeZone { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType left, Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType left, Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderFeaturesRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule>
    {
        public ProviderFeaturesRule(Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy requiredFeaturesPolicy) { }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy RequiredFeaturesPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderFilterRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule>
    {
        public ProviderFilterRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderEndpointInformation> EndpointInformation { get { throw null; } }
        public string FilterQuery { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderFrontloadPayload : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload>
    {
        public ProviderFrontloadPayload(Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties properties) { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayload>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderFrontloadPayloadProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties>
    {
        public ProviderFrontloadPayloadProperties(string operationType, string providerNamespace, string frontloadLocation, string copyFromLocation, Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment environmentType, Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction serviceFeatureFlag, System.Collections.Generic.IEnumerable<string> includeResourceTypes, System.Collections.Generic.IEnumerable<string> excludeResourceTypes, Azure.ResourceManager.ProviderHub.Models.ManifestLevelPropertyBag overrideManifestLevelFields, Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase overrideEndpointLevelFields, System.Collections.Generic.IEnumerable<string> ignoreFields) { }
        public string CopyFromLocation { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.AvailableCheckInManifestEnvironment EnvironmentType { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludeResourceTypes { get { throw null; } }
        public string FrontloadLocation { get { throw null; } }
        public System.Collections.Generic.IList<string> IgnoreFields { get { throw null; } }
        public System.Collections.Generic.IList<string> IncludeResourceTypes { get { throw null; } }
        public string OperationType { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase OverrideEndpointLevelFields { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount> OverrideManifestLevelFieldsResourceHydrationAccounts { get { throw null; } }
        public string ProviderNamespace { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction ServiceFeatureFlag { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderFrontloadPayloadProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderHubExtendedLocationOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>
    {
        public ProviderHubExtendedLocationOptions() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string ExtendedLocationOptionsType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType? LocationType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy? SupportedLocationPolicy { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string SupportedPolicy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public enum ProviderHubExtendedLocationType
    {
        NotSpecified = 0,
        EdgeZone = 1,
        ArcZone = 2,
        CustomLocation = 3,
    }
    public partial class ProviderHubMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata>
    {
        public ProviderHubMetadata() { }
        public string DirectRpRoleDefinitionId { get { throw null; } set { } }
        public string GlobalAsyncOperationResourceTypeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public string RegionalAsyncOperationResourceTypeName { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderLegacyOperation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderLegacyOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation Action { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation AzureAsyncOperationWaiting { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation Create { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation DeploymentCleanup { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation EvaluateDeploymentOutput { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation Read { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation ResourceCacheWaiting { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation left, Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation left, Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderLocationQuotaRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule>
    {
        public ProviderLocationQuotaRule() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy? Policy { get { throw null; } set { } }
        public string QuotaId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderNotification : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderNotification>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderNotification>
    {
        public ProviderNotification() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType? NotificationType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SkipNotification? SkipNotifications { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderNotification System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderNotification>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderNotification>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderNotification System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderNotification>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderNotification>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderNotification>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderNotificationEndpointType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderNotificationEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType Eventhub { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType Webhook { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType left, Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType left, Azure.ResourceManager.ProviderHub.Models.ProviderNotificationEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderNotificationOption : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderNotificationOption(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption EmitSpendingLimit { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption left, Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption left, Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderNotificationType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderNotificationType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType SubscriptionNotification { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType left, Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType left, Azure.ResourceManager.ProviderHub.Models.ProviderNotificationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderQuotaPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderQuotaPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy Default { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy Restricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy left, Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy left, Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderQuotaRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule>
    {
        public ProviderQuotaRule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderLocationQuotaRule> LocationRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderQuotaPolicy? QuotaPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderRegistrationKind : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderRegistrationKind(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind Direct { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind Hybrid { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind left, Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind left, Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderRegistrationProperties : Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>
    {
        public ProviderRegistrationProperties() { }
        public System.Collections.Generic.IList<string> PrivateResourceProviderAllowedSubscriptions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubMetadata ProviderHubMetadata { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecifications { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration TokenAuthConfiguration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRegistrationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProviderRequestHeaderOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions>
    {
        public ProviderRequestHeaderOptions() { }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.OptOutHeaderType? OptOutHeaders { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderResourceQueryFilterOption : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderResourceQueryFilterOption(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption EnableSubscriptionFilterOnTenant { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption left, Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption left, Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProviderResourceSubType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProviderResourceSubType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType AsyncOperation { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType left, Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType left, Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProviderResourceType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType>
    {
        internal ProviderResourceType() { }
        public Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceType? AdditionalOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedUnauthorizedActions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension> AllowedUnauthorizedActionsExtensions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules AsyncOperationPollingRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> AuthorizationActionMappings { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? CrossTenantTokenValidation { get { throw null; } }
        public string DefaultApiVersion { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DisallowedActionVerbs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> ExtendedLocations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> LinkedAccessChecks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule> LinkedNotificationRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> LinkedOperationRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.LoggingRule> LoggingRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.IdentityManagementType? ManagementType { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.MarketplaceType? MarketplaceType { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> Notifications { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule QuotaRule { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions RequestHeaderOptions { get { throw null; } }
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
    public partial class ResourceAccessRole : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole>
    {
        public ResourceAccessRole() { }
        public System.Collections.Generic.IList<string> Actions { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedGroupClaims { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceConcurrencyControlOption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption>
    {
        public ResourceConcurrencyControlOption() { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy? Policy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceConcurrencyPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceConcurrencyPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy SynchronizeBeginExtension { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyPolicy right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ResourceGraphConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration>
    {
        public ResourceGraphConfiguration() { }
        public string ApiVersion { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHydrationAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount>
    {
        public ResourceHydrationAccount() { }
        public string AccountName { get { throw null; } set { } }
        public string EncryptedKey { get { throw null; } set { } }
        public long? MaxChildResourceConsistencyJobLimit { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceManagementAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>
    {
        public ResourceManagementAction() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceManagementEntity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity>
    {
        public ResourceManagementEntity(Azure.Core.ResourceIdentifier resourceId) { }
        public string HomeTenantId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceManagementEntity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceManagementSupportedOperation : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceManagementSupportedOperation(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation Delete { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation Get { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation left, Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation left, Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation right) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension> AllowedThirdPartyExtensions { get { throw null; } }
        public string ApplicationId { get { throw null; } set { } }
        public string GroupingTag { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization ManagedByAuthorization { get { throw null; } set { } }
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
        public ResourceProviderEndpoint() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType? EndpointType { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public string SkuLink { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderManagedByAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization>
    {
        public ResourceProviderManagedByAuthorization() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderAdditionalAuthorization> AdditionalAuthorizations { get { throw null; } }
        public bool? DoesAllowManagedByInheritance { get { throw null; } set { } }
        public string ManagedByResourceRoleDefinitionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagedByAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderManagement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement>
    {
        public ResourceProviderManagement() { }
        public System.Collections.Generic.IList<string> AuthorizationOwners { get { throw null; } }
        public System.Collections.Generic.IList<string> CanaryManifestOwners { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ExpeditedRolloutMetadata ExpeditedRolloutMetadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExpeditedRolloutSubmitters { get { throw null; } }
        public string IncidentContactEmail { get { throw null; } set { } }
        public string IncidentRoutingService { get { throw null; } set { } }
        public string IncidentRoutingTeam { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ManifestOwners { get { throw null; } }
        public string ProfitCenterCode { get { throw null; } set { } }
        public string ProfitCenterProgramId { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceAccessPolicy? ResourceAccessPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceAccessRole> ResourceAccessRoleList { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This property has been deprecated, please use `ResourceAccessRoleList` instead.", false)]
        public System.Collections.Generic.IList<System.BinaryData> ResourceAccessRoles { get { throw null; } }
        public System.Collections.Generic.IList<string> SchemaOwners { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType? ServerFailureResponseMessageType { get { throw null; } set { } }
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
        public Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules AsyncOperationPollingRules { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? CrossTenantTokenValidation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> GlobalNotificationEndpoints { get { throw null; } }
        public bool? IsTenantLinkedNotificationEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule> LinkedNotificationRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement Management { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } }
        public string Namespace { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> Notifications { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? ProviderType { get { throw null; } }
        public string ProviderVersion { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions RequestHeaderOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ReRegisterSubscriptionMetadata ReRegisterSubscriptionMetadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ProviderResourceType> ResourceTypes { get { throw null; } }
        public string ServiceName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService> Services { get { throw null; } }
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
        public Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules AsyncOperationPollingRules { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? CrossTenantTokenValidation { get { throw null; } set { } }
        public string CustomManifestVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration DstsConfiguration { get { throw null; } set { } }
        public bool? EnableTenantLinkedNotification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> GlobalNotificationEndpoints { get { throw null; } }
        public string LegacyNamespace { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LegacyRegistrations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.FanoutLinkedNotificationRule> LinkedNotificationRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement Management { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderEndpoint> ManagementGroupGlobalNotificationEndpoints { get { throw null; } }
        public System.BinaryData Metadata { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderNotificationOption? NotificationOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> Notifications { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting> NotificationSubscriberSettings { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> OptionalFeatures { get { throw null; } }
        public System.Collections.Generic.IList<string> ProviderAuthenticationAllowedAudiences { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderAuthorization> ProviderAuthorizations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderType? ProviderType { get { throw null; } set { } }
        public string ProviderVersion { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions RequestHeaderOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.BlockActionVerb? ResourceGroupLockOptionDuringMoveBlockActionVerb { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceHydrationAccount> ResourceHydrationAccounts { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType? ServiceClientOptionsType { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService> Services { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions TemplateDeploymentOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderManifestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceProviderService : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService>
    {
        public ResourceProviderService() { }
        public string ServiceName { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderService System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceProviderService System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceProviderService>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProviderServiceStatus : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProviderServiceStatus(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus Active { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus left, Azure.ResourceManager.ProviderHub.Models.ResourceProviderServiceStatus right) { throw null; }
        public override string ToString() { throw null; }
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
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType BypassEndpointSelectionOptimization { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType CascadeAuthorizedExtension { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType CascadeExtension { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType ChildFanout { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Default { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Extension { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Failover { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType Fanout { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType HostBased { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType LocationBased { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType LocationMapping { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType ProxyOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType ServiceFanout { get { throw null; } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeCategory : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeCategory(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory FreeForm { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory Internal { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory PureProxy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeDataBoundary : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeDataBoundary(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary EU { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary Global { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary NotDefined { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary US { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>
    {
        public ResourceTypeEndpoint() { }
        public string ApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeDataBoundary? DataBoundary { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration DstsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderEndpointTypeResourceType? EndpointType { get { throw null; } set { } }
        public System.Uri EndpointUri { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtension> Extensions { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind? Kind { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public string SkuLink { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration TokenAuthConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeEndpointBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase>
    {
        public ResourceTypeEndpointBase(bool enabled, System.Collections.Generic.IEnumerable<string> apiVersions, System.Uri endpointUri, System.Collections.Generic.IEnumerable<string> locations, System.Collections.Generic.IEnumerable<string> requiredFeatures, Azure.ResourceManager.ProviderHub.Models.ProviderFeaturesRule featuresRule, System.TimeSpan timeout, Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType endpointType, Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration dstsConfiguration, string skuLink, string apiVersion, System.Collections.Generic.IEnumerable<string> zones) { }
        public string ApiVersion { get { throw null; } }
        public System.Collections.Generic.IList<string> ApiVersions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration DstsConfiguration { get { throw null; } }
        public bool Enabled { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderEndpointType EndpointType { get { throw null; } }
        public System.Uri EndpointUri { get { throw null; } }
        public System.Collections.Generic.IList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } }
        public string SkuLink { get { throw null; } }
        public System.TimeSpan Timeout { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeEndpointKind : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeEndpointKind(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind Direct { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpointKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeExtendedLocationPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeExtendedLocationPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy All { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtendedLocationPolicy right) { throw null; }
        public override string ToString() { throw null; }
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
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory BestMatchOperationBegin { get { throw null; } }
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
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeExtensionCategory SubscriptionLifecycleNotificationDeletion { get { throw null; } }
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
    public partial class ResourceTypeOnBehalfOfToken : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken>
    {
        public ResourceTypeOnBehalfOfToken() { }
        public string ActionName { get { throw null; } set { } }
        public string LifeTime { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeRegistrationApiProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile>
    {
        public ResourceTypeRegistrationApiProfile() { }
        public string ApiVersion { get { throw null; } set { } }
        public string ProfileVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeRegistrationCapacityPolicy : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeRegistrationCapacityPolicy(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy Default { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy Restricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeRegistrationCapacityRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule>
    {
        public ResourceTypeRegistrationCapacityRule() { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityPolicy? CapacityPolicy { get { throw null; } set { } }
        public string SkuAlias { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeRegistrationDeleteDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency>
    {
        public ResourceTypeRegistrationDeleteDependency() { }
        public string LinkedProperty { get { throw null; } set { } }
        public string LinkedType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceTypeRegistrationKind : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceTypeRegistrationKind(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind Direct { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind Hybrid { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind Managed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind left, Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceTypeRegistrationLegacyPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy>
    {
        public ResourceTypeRegistrationLegacyPolicy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LegacyDisallowedCondition> DisallowedConditions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderLegacyOperation> DisallowedLegacyOperations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeRegistrationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationProperties>
    {
        public ResourceTypeRegistrationProperties() { }
        public Azure.ResourceManager.ProviderHub.Models.AdditionalOptionResourceTypeRegistration? AdditionalOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.AllowedResourceName> AllowedResourceNames { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedTemplateDeploymentReferenceActions { get { throw null; } }
        public System.Collections.Generic.IList<string> AllowedUnauthorizedActions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.AllowedUnauthorizedActionsExtension> AllowedUnauthorizedActionsExtensions { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationApiProfile> ApiProfiles { get { throw null; } }
        public bool? AreTagsSupported { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.AsyncOperationPollingRules AsyncOperationPollingRules { get { throw null; } set { } }
        public string AsyncOperationResourceTypeName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.AsyncTimeoutRule> AsyncTimeoutRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.AuthorizationActionMapping> AuthorizationActionMappings { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.AvailabilityZonePolicy? AvailabilityZonePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationCapacityRule CapacityRule { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeCategory? Category { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.CheckNameAvailabilitySpecifications CheckNameAvailabilitySpecifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CommonApiVersions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.CommonApiVersionsMergeMode? CommonApiVersionsMergeMode { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.CrossTenantTokenValidation? CrossTenantTokenValidation { get { throw null; } set { } }
        public string DefaultApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DisallowedActionVerbs { get { throw null; } }
        public System.Collections.Generic.IList<string> DisallowedEndUserOperations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderDstsConfiguration DstsConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeEndpoint> Endpoints { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationOptions> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ExtensionOptions ExtensionOptionsResourceCreationBegin { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.FrontdoorRequestMode? FrontdoorRequestMode { get { throw null; } set { } }
        public string GroupingTag { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.IdentityManagementProperties IdentityManagement { get { throw null; } set { } }
        public bool? IsAddOnPlanConversionAllowed { get { throw null; } set { } }
        public bool? IsAddResourceListTargetLocationsAllowed { get { throw null; } set { } }
        public bool? IsAsyncOperationEnabled { get { throw null; } set { } }
        public bool? IsEmptyRoleAssignmentsAllowed { get { throw null; } set { } }
        public bool? IsNoncompliantCollectionResponseAllowed { get { throw null; } set { } }
        public bool? IsPureProxy { get { throw null; } set { } }
        public bool? IsThirdPartyS2SEnabled { get { throw null; } set { } }
        public string LegacyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LegacyNames { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationLegacyPolicy LegacyPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LinkedAccessCheck> LinkedAccessChecks { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LinkedNotificationRule> LinkedNotificationRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LinkedOperationRule> LinkedOperationRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.LoggingRule> LoggingRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceProviderManagement Management { get { throw null; } set { } }
        public string ManifestLink { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.MarketplaceType? MarketplaceType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderNotification> Notifications { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeOnBehalfOfToken OnBehalfOfTokens { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.OptInHeaderType? OptInHeaders { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.PolicyExecutionType? PolicyExecutionType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderQuotaRule QuotaRule { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationRegionality? Regionality { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderRequestHeaderOptions RequestHeaderOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.FeaturesPolicy? RequiredFeaturesPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache ResourceCache { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.ProviderHub.Models.ResourceConcurrencyControlOption> ResourceConcurrencyControlOptions { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceDeletionPolicy? ResourceDeletionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceGraphConfiguration ResourceGraphConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions ResourceManagementOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceMovePolicy ResourceMovePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderResourceQueryFilterOption? ResourceQueryManagementFilterOption { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderResourceSubType? ResourceSubType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceValidation? ResourceValidation { get { throw null; } set { } }
        public string RoutingRuleHostResourceType { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ResourceRoutingType? RoutingType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo> ServiceTreeInfos { get { throw null; } }
        public string SkuLink { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SubscriptionLifecycleNotificationSpecifications SubscriptionLifecycleNotificationSpecifications { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderSubscriptionStateRule> SubscriptionStateRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.SwaggerSpecification> SwaggerSpecifications { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentOptions TemplateDeploymentOptions { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy TemplateDeploymentPolicy { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule> ThrottlingRules { get { throw null; } }
        public Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration TokenAuthConfiguration { get { throw null; } set { } }
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
    public partial class ResourceTypeRegistrationResourceCache : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache>
    {
        public ResourceTypeRegistrationResourceCache() { }
        public bool? IsResourceCacheEnabled { get { throw null; } set { } }
        public string ResourceCacheExpirationTimespan { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceCache>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceTypeRegistrationResourceManagementOptions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions>
    {
        public ResourceTypeRegistrationResourceManagementOptions() { }
        public Azure.ResourceManager.ProviderHub.Models.ResourceManagementSupportedOperation? BatchProvisioningSupportSupportedOperations { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationDeleteDependency> DeleteDependencies { get { throw null; } }
        public string NestedProvisioningSupportMinimumApiVersion { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ResourceTypeRegistrationResourceManagementOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.ResourceManager.ProviderHub.Models.ProviderHubExtendedLocationType? ExtendedLocationType { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ProviderExtendedLocationType? LocationType { get { throw null; } set { } }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServerFailureResponseMessageType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServerFailureResponseMessageType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType OutageReporting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType left, Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType left, Azure.ResourceManager.ProviderHub.Models.ServerFailureResponseMessageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceClientOptionsType : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceClientOptionsType(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType DisableAutomaticDecompression { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType NotSpecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType left, Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType left, Azure.ResourceManager.ProviderHub.Models.ServiceClientOptionsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceFeatureFlagAction : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceFeatureFlagAction(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction Create { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction DoNotCreate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction left, Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction left, Azure.ResourceManager.ProviderHub.Models.ServiceFeatureFlagAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ServiceTreeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>
    {
        public ServiceTreeInfo() { }
        public string ComponentId { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness? Readiness { get { throw null; } set { } }
        public string ServiceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ServiceTreeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ServiceTreeReadiness : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ServiceTreeReadiness(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness ClosingDown { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness Deprecated { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness GA { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness InDevelopment { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness InternalOnly { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness PrivatePreview { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness PublicPreview { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness RemovedFromARM { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness Retired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness left, Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness left, Azure.ResourceManager.ProviderHub.Models.ServiceTreeReadiness right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SignedRequestScope : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SignedRequestScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SignedRequestScope(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SignedRequestScope Endpoint { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SignedRequestScope ResourceUri { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SignedRequestScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SignedRequestScope left, Azure.ResourceManager.ProviderHub.Models.SignedRequestScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SignedRequestScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SignedRequestScope left, Azure.ResourceManager.ProviderHub.Models.SignedRequestScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkipNotification : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.SkipNotification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkipNotification(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.SkipNotification Disabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SkipNotification Enabled { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.SkipNotification Unspecified { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.SkipNotification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.SkipNotification left, Azure.ResourceManager.ProviderHub.Models.SkipNotification right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.SkipNotification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.SkipNotification left, Azure.ResourceManager.ProviderHub.Models.SkipNotification right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriberSetting : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting>
    {
        public SubscriberSetting() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ProviderFilterRule> FilterRules { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SubscriberSetting System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.SubscriberSetting System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.SubscriberSetting>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public TemplateDeploymentPolicy(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability capabilities, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption preflightOptions) { }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentCapability Capabilities { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification? PreflightNotifications { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightOption PreflightOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateDeploymentPreflightNotification : System.IEquatable<Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateDeploymentPreflightNotification(string value) { throw null; }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification None { get { throw null; } }
        public static Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification UnregisteredSubscriptions { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification right) { throw null; }
        public static implicit operator Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification left, Azure.ResourceManager.ProviderHub.Models.TemplateDeploymentPreflightNotification right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class ThirdPartyExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension>
    {
        public ThirdPartyExtension() { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThirdPartyExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public System.Collections.Generic.IList<string> ApplicationId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ProviderHub.Models.ThrottlingMetric> Metrics { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredFeatures { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThrottlingRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.ThrottlingRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.ThrottlingRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TokenAuthConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration>
    {
        public TokenAuthConfiguration() { }
        public Azure.ResourceManager.ProviderHub.Models.ProviderAuthenticationScheme? AuthenticationScheme { get { throw null; } set { } }
        public bool? DisableCertificateAuthenticationFallback { get { throw null; } set { } }
        public Azure.ResourceManager.ProviderHub.Models.SignedRequestScope? SignedRequestScope { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ProviderHub.Models.TokenAuthConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
