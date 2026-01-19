namespace Azure.ResourceManager.EdgeActions
{
    public partial class AzureResourceManagerEdgeActionsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEdgeActionsContext() { }
        public static Azure.ResourceManager.EdgeActions.AzureResourceManagerEdgeActionsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EdgeActionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionResource>, System.Collections.IEnumerable
    {
        protected EdgeActionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string edgeActionName, Azure.ResourceManager.EdgeActions.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string edgeActionName, Azure.ResourceManager.EdgeActions.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> Get(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> GetAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetIfExists(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeActions.EdgeActionResource>> GetIfExistsAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeActions.EdgeActionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeActions.EdgeActionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeActionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>
    {
        public EdgeActionData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType sku) { }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.EdgeActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.EdgeActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionExecutionFilterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>, System.Collections.IEnumerable
    {
        protected EdgeActionExecutionFilterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string executionFilter, Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string executionFilter, Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> Get(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> GetAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> GetIfExists(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> GetIfExistsAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeActionExecutionFilterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>
    {
        public EdgeActionExecutionFilterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionExecutionFilterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeActionExecutionFilterResource() { }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeActionName, string executionFilter) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeActionResource() { }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult> AddAttachment(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>> AddAttachmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeActionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteAttachment(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAttachmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> GetEdgeActionExecutionFilter(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> GetEdgeActionExecutionFilterAsync(string executionFilter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterCollection GetEdgeActionExecutionFilters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> GetEdgeActionVersion(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> GetEdgeActionVersionAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionVersionCollection GetEdgeActionVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeActions.EdgeActionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.EdgeActionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.EdgeActionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class EdgeActionsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetEdgeAction(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> GetEdgeActionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource GetEdgeActionExecutionFilterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionResource GetEdgeActionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionCollection GetEdgeActions(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetEdgeActions(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetEdgeActionsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionVersionResource GetEdgeActionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class EdgeActionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeActionVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.EdgeActions.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string version, Azure.ResourceManager.EdgeActions.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> Get(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> GetAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> GetIfExists(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> GetIfExistsAsync(string version, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeActionVersionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>
    {
        public EdgeActionVersionData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.EdgeActionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.EdgeActionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeActionVersionResource() { }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeActionName, string version) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties> DeployVersionCode(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>> DeployVersionCodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode> GetVersionCode(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>> GetVersionCodeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation SwapDefault(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> SwapDefaultAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeActions.EdgeActionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.EdgeActionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.EdgeActionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeActions.Mocking
{
    public partial class MockableEdgeActionsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeActionsArmClient() { }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource GetEdgeActionExecutionFilterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionResource GetEdgeActionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionVersionResource GetEdgeActionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEdgeActionsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeActionsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetEdgeAction(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> GetEdgeActionAsync(string edgeActionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionCollection GetEdgeActions() { throw null; }
    }
    public partial class MockableEdgeActionsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeActionsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetEdgeActions(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.EdgeActions.EdgeActionResource> GetEdgeActionsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeActions.Models
{
    public static partial class ArmEdgeActionsModelFactory
    {
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment EdgeActionAttachment(string id = null, Azure.Core.ResourceIdentifier attachedResourceId = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult EdgeActionAttachmentResult(string edgeActionId = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionData EdgeActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties properties = null, Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType sku = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData EdgeActionExecutionFilterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties properties = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties EdgeActionExecutionFilterProperties(Azure.Core.ResourceIdentifier versionId = null, System.DateTimeOffset lastUpdatedOn = default(System.DateTimeOffset), string executionFilterIdentifierHeaderName = null, string executionFilterIdentifierHeaderValue = null, Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties EdgeActionProperties(Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment> attachments = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionVersionData EdgeActionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties EdgeActionVersionProperties(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType deploymentType = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType), Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus validationStatus = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus), Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState?), Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion isDefaultVersion = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion), System.DateTimeOffset lastPackageUpdatedOn = default(System.DateTimeOffset)) { throw null; }
    }
    public partial class EdgeActionAttachment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>
    {
        public EdgeActionAttachment(Azure.Core.ResourceIdentifier attachedResourceId) { }
        public Azure.Core.ResourceIdentifier AttachedResourceId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionAttachmentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>
    {
        internal EdgeActionAttachmentResult() { }
        public string EdgeActionId { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionExecutionFilterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties>
    {
        public EdgeActionExecutionFilterProperties(Azure.Core.ResourceIdentifier versionId, string executionFilterIdentifierHeaderName, string executionFilterIdentifierHeaderValue) { }
        public string ExecutionFilterIdentifierHeaderName { get { throw null; } set { } }
        public string ExecutionFilterIdentifierHeaderValue { get { throw null; } set { } }
        public System.DateTimeOffset LastUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VersionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeActionIsDefaultVersion : System.IEquatable<Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeActionIsDefaultVersion(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion False { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion True { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion left, Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion left, Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeActionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties>
    {
        public EdgeActionProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment> Attachments { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeActionProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeActionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState left, Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState left, Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeActionSkuType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType>
    {
        public EdgeActionSkuType(string name, string tier) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionSkuType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionVersionCode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>
    {
        public EdgeActionVersionCode(string content, string name) { }
        public string Content { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionCode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeActionVersionDeploymentType : System.IEquatable<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeActionVersionDeploymentType(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType File { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType Others { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType Zip { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeActionVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>
    {
        public EdgeActionVersionProperties(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType deploymentType, Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion isDefaultVersion) { }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType DeploymentType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion IsDefaultVersion { get { throw null; } set { } }
        public System.DateTimeOffset LastPackageUpdatedOn { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus ValidationStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeActionVersionValidationStatus : System.IEquatable<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeActionVersionValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
