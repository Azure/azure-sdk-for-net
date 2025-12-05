namespace Azure.ResourceManager.EdgeActionsApi
{
    public partial class AzureResourceManagerEdgeActionsApiContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEdgeActionsApiContext() { }
        public static Azure.ResourceManager.EdgeActionsApi.AzureResourceManagerEdgeActionsApiContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EdgeActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>, System.Collections.IEnumerable
    {
        protected EdgeActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string edgeActionName, Azure.ResourceManager.EdgeActionsApi.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string edgeActionName, Azure.ResourceManager.EdgeActionsApi.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> Get(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> GetAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetIfExists(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> GetIfExistsAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeActionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>
    {
        public EdgeActionData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeActionsApi.Models.SkuType sku) { }
        public Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeActionsApi.Models.SkuType Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionExecutionFilterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>, System.Collections.IEnumerable
    {
        protected EdgeActionExecutionFilterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string executionFilter, Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string executionFilter, Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> Get(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> GetAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> GetIfExists(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> GetIfExistsAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeActionExecutionFilterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>
    {
        public EdgeActionExecutionFilterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionExecutionFilterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeActionExecutionFilterResource() { }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeActionName, string executionFilter) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeActionResource() { }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult> AddAttachment(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>> AddAttachmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeActionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteAttachment(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAttachmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource> GetEdgeActionExecutionFilter(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource>> GetEdgeActionExecutionFilterAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterCollection GetEdgeActionExecutionFilters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> GetEdgeActionVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> GetEdgeActionVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionCollection GetEdgeActionVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EdgeActionsApiExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetEdgeAction(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> GetEdgeActionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource GetEdgeActionExecutionFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.EdgeActionResource GetEdgeActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.EdgeActionCollection GetEdgeActions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetEdgeActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetEdgeActionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource GetEdgeActionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class EdgeActionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeActionVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeActionVersionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>
    {
        public EdgeActionVersionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeActionVersionResource() { }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeActionName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties> DeployVersionCode(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.Models.VersionCode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>> DeployVersionCodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.Models.VersionCode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode> GetVersionCode(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>> GetVersionCodeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SwapDefault(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SwapDefaultAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeActionsApi.Mocking
{
    public partial class MockableEdgeActionsApiArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeActionsApiArmClient() { }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterResource GetEdgeActionExecutionFilterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionResource GetEdgeActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionResource GetEdgeActionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEdgeActionsApiResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeActionsApiResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetEdgeAction(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource>> GetEdgeActionAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeActionsApi.EdgeActionCollection GetEdgeActions() { throw null; }
    }
    public partial class MockableEdgeActionsApiSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeActionsApiSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetEdgeActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActionsApi.EdgeActionResource> GetEdgeActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeActionsApi.Models
{
    public static partial class ArmEdgeActionsApiModelFactory
    {
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment EdgeActionAttachment(string id = null, Azure.Core.ResourceIdentifier attachedResourceId = null) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult EdgeActionAttachmentResult(string edgeActionId = null) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.EdgeActionData EdgeActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties properties = null, Azure.ResourceManager.EdgeActionsApi.Models.SkuType sku = null) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.EdgeActionExecutionFilterData EdgeActionExecutionFilterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties EdgeActionExecutionFilterProperties(Azure.Core.ResourceIdentifier versionId = null, System.DateTimeOffset lastUpdateOn = default(System.DateTimeOffset), string executionFilterIdentifierHeaderName = null, string executionFilterIdentifierHeaderValue = null, Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties EdgeActionProperties(Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment> attachments = null) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.EdgeActionVersionData EdgeActionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties EdgeActionVersionProperties(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType deploymentType = default(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType), Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus validationStatus = default(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus), Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState?), Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion isDefaultVersion = default(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion), System.DateTimeOffset lastPackageUpdateOn = default(System.DateTimeOffset)) { throw null; }
    }
    public partial class EdgeActionAttachment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment>
    {
        public EdgeActionAttachment(Azure.Core.ResourceIdentifier attachedResourceId) { }
        public Azure.Core.ResourceIdentifier AttachedResourceId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionAttachmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>
    {
        internal EdgeActionAttachmentResult() { }
        public string EdgeActionId { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionExecutionFilterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties>
    {
        public EdgeActionExecutionFilterProperties(Azure.Core.ResourceIdentifier versionId, string executionFilterIdentifierHeaderName, string executionFilterIdentifierHeaderValue) { }
        public string ExecutionFilterIdentifierHeaderName { get { throw null; } set { } }
        public string ExecutionFilterIdentifierHeaderValue { get { throw null; } set { } }
        public System.DateTimeOffset LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VersionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionExecutionFilterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeActionIsDefaultVersion : System.IEquatable<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeActionIsDefaultVersion(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion False { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion left, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion left, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties>
    {
        public EdgeActionProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionAttachment> Attachments { get { throw null; } }
        public Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeActionVersionDeploymentType : System.IEquatable<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeActionVersionDeploymentType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType File { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType Others { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType Zip { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType left, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType left, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeActionVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>
    {
        public EdgeActionVersionProperties(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType deploymentType, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion isDefaultVersion) { }
        public Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionDeploymentType DeploymentType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionIsDefaultVersion IsDefaultVersion { get { throw null; } set { } }
        public System.DateTimeOffset LastPackageUpdateOn { get { throw null; } }
        public Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeActionVersionValidationStatus : System.IEquatable<Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeActionVersionValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus left, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus left, Azure.ResourceManager.EdgeActionsApi.Models.EdgeActionVersionValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState left, Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState left, Azure.ResourceManager.EdgeActionsApi.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.SkuType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.SkuType>
    {
        public SkuType(string name, string tier) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.SkuType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.SkuType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.Models.SkuType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.SkuType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.SkuType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.Models.SkuType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.SkuType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.SkuType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.SkuType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionCode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>
    {
        public VersionCode(string content, string name) { }
        public string Content { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.VersionCode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActionsApi.Models.VersionCode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActionsApi.Models.VersionCode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActionsApi.Models.VersionCode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActionsApi.Models.VersionCode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
