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
        public EdgeActionData(Azure.Core.AzureLocation location, Azure.ResourceManager.EdgeActions.Models.SkuType sku) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment> Attachments { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.SkuType Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public string ExecutionFilterIdentifierHeaderName { get { throw null; } set { } }
        public string ExecutionFilterIdentifierHeaderValue { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdateOn { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier VersionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeActionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.EdgeActionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.EdgeActionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeActionResource() { }
        public virtual Azure.ResourceManager.EdgeActions.EdgeActionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse> AddAttachment(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>> AddAttachmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string edgeActionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteAttachment(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAttachmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType? DeploymentType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion? IsDefaultVersion { get { throw null; } set { } }
        public System.DateTimeOffset? LastPackageUpdateOn { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus? ValidationStatus { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties> DeployVersionCode(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.VersionCode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>> DeployVersionCodeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.VersionCode body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.VersionCode> GetVersionCode(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.Models.VersionCode>> GetVersionCodeAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.EdgeActions.EdgeActionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse EdgeActionAttachmentResponse(string edgeActionId = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionData EdgeActionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActions.Models.SkuType sku = null, Azure.ResourceManager.EdgeActions.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActions.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment> attachments = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionExecutionFilterData EdgeActionExecutionFilterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier versionId = null, System.DateTimeOffset? lastUpdateOn = default(System.DateTimeOffset?), string executionFilterIdentifierHeaderName = null, string executionFilterIdentifierHeaderValue = null, Azure.ResourceManager.EdgeActions.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActions.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch EdgeActionExecutionFilterPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier versionId = null, string executionFilterIdentifierHeaderName = null, string executionFilterIdentifierHeaderValue = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch EdgeActionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.BinaryData properties = null, Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate sku = null, System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.EdgeActionVersionData EdgeActionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType? deploymentType = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType?), Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus? validationStatus = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus?), Azure.ResourceManager.EdgeActions.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActions.Models.ProvisioningState?), Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion? isDefaultVersion = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion?), System.DateTimeOffset? lastPackageUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch EdgeActionVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType? deploymentType = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType?), Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion? isDefaultVersion = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties EdgeActionVersionProperties(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType deploymentType = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType), Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus validationStatus = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus), Azure.ResourceManager.EdgeActions.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.EdgeActions.Models.ProvisioningState?), Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion isDefaultVersion = default(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion), System.DateTimeOffset lastPackageUpdateOn = default(System.DateTimeOffset)) { throw null; }
    }
    public partial class EdgeActionAttachment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>
    {
        public EdgeActionAttachment(string id, Azure.Core.ResourceIdentifier attachedResourceId) { }
        public Azure.Core.ResourceIdentifier AttachedResourceId { get { throw null; } set { } }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionAttachmentResponse : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>
    {
        internal EdgeActionAttachmentResponse() { }
        public string EdgeActionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionAttachmentResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionExecutionFilterPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch>
    {
        public EdgeActionExecutionFilterPatch() { }
        public string ExecutionFilterIdentifierHeaderName { get { throw null; } set { } }
        public string ExecutionFilterIdentifierHeaderValue { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier VersionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionExecutionFilterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion left, Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion left, Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeActionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch>
    {
        public EdgeActionPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeActionVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch>
    {
        public EdgeActionVersionPatch() { }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType? DeploymentType { get { throw null; } set { } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion? IsDefaultVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeActionVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionProperties>
    {
        internal EdgeActionVersionProperties() { }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionDeploymentType DeploymentType { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionIsDefaultVersion IsDefaultVersion { get { throw null; } }
        public System.DateTimeOffset LastPackageUpdateOn { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus left, Azure.ResourceManager.EdgeActions.Models.EdgeActionVersionValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.EdgeActions.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.EdgeActions.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.EdgeActions.Models.ProvisioningState Upgrading { get { throw null; } }
        public bool Equals(Azure.ResourceManager.EdgeActions.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.EdgeActions.Models.ProvisioningState left, Azure.ResourceManager.EdgeActions.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.EdgeActions.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.EdgeActions.Models.ProvisioningState left, Azure.ResourceManager.EdgeActions.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SkuType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.SkuType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuType>
    {
        public SkuType(string name, string tier) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.SkuType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.SkuType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.SkuType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.SkuType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuTypeUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate>
    {
        public SkuTypeUpdate() { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.SkuTypeUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionCode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.VersionCode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.VersionCode>
    {
        public VersionCode(string content, string name) { }
        public string Content { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.VersionCode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.VersionCode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeActions.Models.VersionCode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeActions.Models.VersionCode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.VersionCode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.VersionCode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeActions.Models.VersionCode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
