namespace Azure.ResourceManager.WorkloadOrchestration
{
    public partial class AzureResourceManagerWorkloadOrchestrationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWorkloadOrchestrationContext() { }
        public static Azure.ResourceManager.WorkloadOrchestration.AzureResourceManagerWorkloadOrchestrationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class EdgeConfigTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>, System.Collections.IEnumerable
    {
        protected EdgeConfigTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configTemplateName, Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configTemplateName, Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> Get(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> GetAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetIfExists(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> GetIfExistsAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeConfigTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>
    {
        public EdgeConfigTemplateData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeConfigTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeConfigTemplateResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> GetEdgeConfigTemplateVersion(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>> GetEdgeConfigTemplateVersionAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionCollection GetEdgeConfigTemplateVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult> RemoveVersion(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>> RemoveVersionAsync(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeConfigTemplateVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeConfigTemplateVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> Get(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>> GetAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> GetIfExists(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>> GetIfExistsAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeConfigTemplateVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>
    {
        public EdgeConfigTemplateVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeConfigTemplateVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeConfigTemplateVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configTemplateName, string configTemplateVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeContextCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>, System.Collections.IEnumerable
    {
        protected EdgeContextCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contextName, Azure.ResourceManager.WorkloadOrchestration.EdgeContextData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contextName, Azure.ResourceManager.WorkloadOrchestration.EdgeContextData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> Get(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> GetAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetIfExists(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> GetIfExistsAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeContextData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>
    {
        public EdgeContextData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeContextData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeContextData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeContextResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeContextResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeContextData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> GetEdgeSiteReference(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>> GetEdgeSiteReferenceAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceCollection GetEdgeSiteReferences() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> GetEdgeWorkflow(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>> GetEdgeWorkflowAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowCollection GetEdgeWorkflows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeContextData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeContextData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeContextData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeDeploymentInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>, System.Collections.IEnumerable
    {
        protected EdgeDeploymentInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> Get(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>> GetAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> GetIfExists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>> GetIfExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeDeploymentInstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>
    {
        public EdgeDeploymentInstanceData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeploymentInstanceHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>, System.Collections.IEnumerable
    {
        protected EdgeDeploymentInstanceHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> Get(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>> GetAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> GetIfExists(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>> GetIfExistsAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeDeploymentInstanceHistoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>
    {
        public EdgeDeploymentInstanceHistoryData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeploymentInstanceHistoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeDeploymentInstanceHistoryResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName, string instanceName, string instanceHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeploymentInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeDeploymentInstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName, string instanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryCollection GetEdgeDeploymentInstanceHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource> GetEdgeDeploymentInstanceHistory(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource>> GetEdgeDeploymentInstanceHistoryAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeDiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>, System.Collections.IEnumerable
    {
        protected EdgeDiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticName, Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticName, Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> Get(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> GetAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetIfExists(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> GetIfExistsAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeDiagnosticData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>
    {
        public EdgeDiagnosticData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? DiagnosticProvisioningState { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDiagnosticResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeDiagnosticResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diagnosticName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeDynamicSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>, System.Collections.IEnumerable
    {
        protected EdgeDynamicSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dynamicSchemaName, Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dynamicSchemaName, Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> Get(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>> GetAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> GetIfExists(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>> GetIfExistsAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeDynamicSchemaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>
    {
        public EdgeDynamicSchemaData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDynamicSchemaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeDynamicSchemaResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName, string dynamicSchemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> GetEdgeDynamicSchemaVersion(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>> GetEdgeDynamicSchemaVersionAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionCollection GetEdgeDynamicSchemaVersions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeDynamicSchemaVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeDynamicSchemaVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dynamicSchemaVersionName, Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dynamicSchemaVersionName, Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> Get(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>> GetAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> GetIfExists(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>> GetIfExistsAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeDynamicSchemaVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>
    {
        public EdgeDynamicSchemaVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDynamicSchemaVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeDynamicSchemaVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName, string dynamicSchemaName, string dynamicSchemaVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>, System.Collections.IEnumerable
    {
        protected EdgeExecutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string executionName, Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string executionName, Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> Get(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>> GetAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> GetIfExists(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>> GetIfExistsAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeExecutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>
    {
        public EdgeExecutionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeExecutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeExecutionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string workflowName, string versionName, string executionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>, System.Collections.IEnumerable
    {
        protected EdgeJobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>
    {
        public EdgeJobData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeJobResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>, System.Collections.IEnumerable
    {
        protected EdgeSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetIfExists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> GetIfExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSchemaData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>
    {
        public EdgeSchemaData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaReferenceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>, System.Collections.IEnumerable
    {
        protected EdgeSchemaReferenceCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> Get(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>> GetAsync(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> GetIfExists(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>> GetIfExistsAsync(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSchemaReferenceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>
    {
        public EdgeSchemaReferenceData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaReferenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSchemaReferenceResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string schemaReferenceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSchemaResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> GetEdgeDynamicSchema(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>> GetEdgeDynamicSchemaAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaCollection GetEdgeDynamicSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> GetEdgeSchemaVersion(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> GetEdgeSchemaVersionAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionCollection GetEdgeSchemaVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult> RemoveVersion(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>> RemoveVersionAsync(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeSchemaVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeSchemaVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaVersionName, Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaVersionName, Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> Get(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> GetAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> GetIfExists(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> GetIfExistsAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSchemaVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>
    {
        public EdgeSchemaVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSchemaVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName, string schemaVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeSiteReferenceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>, System.Collections.IEnumerable
    {
        protected EdgeSiteReferenceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteReferenceName, Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteReferenceName, Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> Get(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>> GetAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> GetIfExists(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>> GetIfExistsAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSiteReferenceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>
    {
        public EdgeSiteReferenceData() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSiteReferenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSiteReferenceResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string siteReferenceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeSolutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>, System.Collections.IEnumerable
    {
        protected EdgeSolutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> Get(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>> GetAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> GetIfExists(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>> GetIfExistsAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSolutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>
    {
        public EdgeSolutionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSolutionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> GetEdgeDeploymentInstance(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>> GetEdgeDeploymentInstanceAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceCollection GetEdgeDeploymentInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> GetEdgeSolutionVersion(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> GetEdgeSolutionVersionAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionCollection GetEdgeSolutionVersions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeSolutionTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>, System.Collections.IEnumerable
    {
        protected EdgeSolutionTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionTemplateName, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionTemplateName, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> Get(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> GetAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetIfExists(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> GetIfExistsAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSolutionTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>
    {
        public EdgeSolutionTemplateData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSolutionTemplateResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> GetEdgeSolutionTemplateVersion(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>> GetEdgeSolutionTemplateVersionAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionCollection GetEdgeSolutionTemplateVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeSolutionTemplateVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeSolutionTemplateVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> Get(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>> GetAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> GetIfExists(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>> GetIfExistsAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSolutionTemplateVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>
    {
        public EdgeSolutionTemplateVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplateVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSolutionTemplateVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation BulkDeploySolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BulkDeploySolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BulkPublishSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BulkPublishSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionTemplateName, string solutionTemplateVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeSolutionVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionVersionName, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionVersionName, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> Get(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> GetAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> GetIfExists(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> GetIfExistsAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeSolutionVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>
    {
        public EdgeSolutionVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeSolutionVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName, string solutionVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeTargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>, System.Collections.IEnumerable
    {
        protected EdgeTargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> Get(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> GetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetIfExists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> GetIfExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeTargetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>
    {
        public EdgeTargetData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeTargetResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource> GetEdgeSolution(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource>> GetEdgeSolutionAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionCollection GetEdgeSolutions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InstallSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InstallSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> PublishSolutionVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> PublishSolutionVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveRevision(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveRevisionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration> ResolveConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>> ResolveConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> ReviewSolutionVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> ReviewSolutionVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UninstallSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UninstallSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> UpdateExternalValidationStatus(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> UpdateExternalValidationStatusAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeWorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>, System.Collections.IEnumerable
    {
        protected EdgeWorkflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> Get(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>> GetAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> GetIfExists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>> GetIfExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeWorkflowData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>
    {
        public EdgeWorkflowData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeWorkflowResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string workflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> GetEdgeWorkflowVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>> GetEdgeWorkflowVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionCollection GetEdgeWorkflowVersions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EdgeWorkflowVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>, System.Collections.IEnumerable
    {
        protected EdgeWorkflowVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class EdgeWorkflowVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>
    {
        public EdgeWorkflowVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected EdgeWorkflowVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string workflowName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> GetEdgeExecution(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>> GetEdgeExecutionAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionCollection GetEdgeExecutions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WorkloadOrchestrationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetEdgeConfigTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> GetEdgeConfigTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource GetEdgeConfigTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateCollection GetEdgeConfigTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetEdgeConfigTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetEdgeConfigTemplatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource GetEdgeConfigTemplateVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetEdgeContext(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> GetEdgeContextAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource GetEdgeContextResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeContextCollection GetEdgeContexts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetEdgeContexts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetEdgeContextsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource GetEdgeDeploymentInstanceHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource GetEdgeDeploymentInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetEdgeDiagnostic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> GetEdgeDiagnosticAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource GetEdgeDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticCollection GetEdgeDiagnostics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetEdgeDiagnostics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetEdgeDiagnosticsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource GetEdgeDynamicSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource GetEdgeDynamicSchemaVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource GetEdgeExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> GetEdgeJob(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>> GetEdgeJobAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource GetEdgeJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeJobCollection GetEdgeJobs(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetEdgeSchema(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> GetEdgeSchemaAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> GetEdgeSchemaReference(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>> GetEdgeSchemaReferenceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource GetEdgeSchemaReferenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceCollection GetEdgeSchemaReferences(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource GetEdgeSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaCollection GetEdgeSchemas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetEdgeSchemas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetEdgeSchemasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource GetEdgeSchemaVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource GetEdgeSiteReferenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource GetEdgeSolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetEdgeSolutionTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> GetEdgeSolutionTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource GetEdgeSolutionTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateCollection GetEdgeSolutionTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetEdgeSolutionTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetEdgeSolutionTemplatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource GetEdgeSolutionTemplateVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource GetEdgeSolutionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetEdgeTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> GetEdgeTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource GetEdgeTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeTargetCollection GetEdgeTargets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetEdgeTargets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetEdgeTargetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource GetEdgeWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource GetEdgeWorkflowVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadOrchestration.Mocking
{
    public partial class MockableWorkloadOrchestrationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadOrchestrationArmClient() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource GetEdgeConfigTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionResource GetEdgeConfigTemplateVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource GetEdgeContextResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryResource GetEdgeDeploymentInstanceHistoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource GetEdgeDeploymentInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource GetEdgeDiagnosticResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource GetEdgeDynamicSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource GetEdgeDynamicSchemaVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource GetEdgeExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource> GetEdgeJob(Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource>> GetEdgeJobAsync(Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeJobResource GetEdgeJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeJobCollection GetEdgeJobs(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource> GetEdgeSchemaReference(Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource>> GetEdgeSchemaReferenceAsync(Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceResource GetEdgeSchemaReferenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceCollection GetEdgeSchemaReferences(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource GetEdgeSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource GetEdgeSchemaVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource GetEdgeSiteReferenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionResource GetEdgeSolutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource GetEdgeSolutionTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource GetEdgeSolutionTemplateVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource GetEdgeSolutionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource GetEdgeTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource GetEdgeWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource GetEdgeWorkflowVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWorkloadOrchestrationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadOrchestrationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetEdgeConfigTemplate(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource>> GetEdgeConfigTemplateAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateCollection GetEdgeConfigTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetEdgeContext(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource>> GetEdgeContextAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeContextCollection GetEdgeContexts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetEdgeDiagnostic(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource>> GetEdgeDiagnosticAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticCollection GetEdgeDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetEdgeSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource>> GetEdgeSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaCollection GetEdgeSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetEdgeSolutionTemplate(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> GetEdgeSolutionTemplateAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateCollection GetEdgeSolutionTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetEdgeTarget(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> GetEdgeTargetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeTargetCollection GetEdgeTargets() { throw null; }
    }
    public partial class MockableWorkloadOrchestrationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadOrchestrationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetEdgeConfigTemplates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateResource> GetEdgeConfigTemplatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetEdgeContexts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeContextResource> GetEdgeContextsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetEdgeDiagnostics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticResource> GetEdgeDiagnosticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetEdgeSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaResource> GetEdgeSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetEdgeSolutionTemplates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> GetEdgeSolutionTemplatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetEdgeTargets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> GetEdgeTargetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadOrchestration.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActiveState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActiveState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState left, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState left, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmWorkloadOrchestrationModelFactory
    {
        public static Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion AvailableSolutionTemplateVersion(string solutionTemplateVersion = null, string latestConfigRevision = null, bool isConfigured = false) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails BulkPublishTargetDetails(Azure.Core.ResourceIdentifier targetId = null, string solutionInstanceName = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus ComponentStatus(string name = null, string status = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties ConfigTemplateProperties(string description = null, string latestVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties ConfigTemplateVersionProperties(string configurations = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType ConfigTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData configTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties ContextProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.Capability> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy> hierarchies = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus DeploymentStatus(System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), int? deployed = default(int?), int? expectedRunningJobId = default(int?), int? runningJobId = default(int?), string status = null, string statusDetails = null, int? generation = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus> targetStatuses = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties DynamicSchemaProperties(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType? configurationType = default(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType?), Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel? configurationModel = default(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData EdgeConfigTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData EdgeConfigTemplateVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeContextData EdgeContextData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData EdgeDeploymentInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties properties = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData EdgeDeploymentInstanceHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties properties = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch EdgeDeploymentInstancePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData EdgeDiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? diagnosticProvisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?), Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData EdgeDynamicSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch EdgeDynamicSchemaPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData EdgeDynamicSchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch EdgeDynamicSchemaVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string schemaVersionPropertiesUpdateValue = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData EdgeExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties properties = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch EdgeExecutionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeJobData EdgeJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData EdgeSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData EdgeSchemaReferenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData EdgeSchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch EdgeSchemaVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string schemaVersionPropertiesUpdateValue = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData EdgeSiteReferenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch EdgeSiteReferencePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string siteId = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData EdgeSolutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties properties = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData EdgeSolutionTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData EdgeSolutionTemplateVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData EdgeSolutionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties properties = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch EdgeSolutionVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, System.BinaryData> solutionVersionPropertiesUpdateSpecification = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData EdgeTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties properties = null, string etag = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData EdgeWorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties properties = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch EdgeWorkflowPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData EdgeWorkflowVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties properties = null, Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch EdgeWorkflowVersionPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties ExecutionProperties(string workflowVersionId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus status = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus ExecutionStatus(System.DateTimeOffset? updateOn = default(System.DateTimeOffset?), int? status = default(int?), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus> stageHistory = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties InstanceHistoryProperties(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot solutionVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot target = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? activeState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState?), Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties reconciliationPolicy = null, Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus status = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties InstanceProperties(string solutionVersionId = null, string targetId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? activeState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState?), Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties reconciliationPolicy = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus status = null, long? deploymentTimestampEpoch = default(long?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties JobProperties(Azure.ResourceManager.WorkloadOrchestration.Models.JobType jobType = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobType), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus status = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus), Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase jobParameter = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> steps = null, string triggeredBy = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobStep JobStep(string name = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus status = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string message = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase statistics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> steps = null, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration ResolvedConfiguration(string configuration = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties SchemaProperties(string currentVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties SchemaReferenceProperties(string schemaId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties SchemaVersionProperties(string value = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType SchemaVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties SiteReferenceProperties(string siteId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency SolutionDependency(string solutionVersionId = null, string solutionInstanceName = null, string solutionTemplateVersionId = null, string targetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency> dependencies = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties SolutionProperties(string solutionTemplateId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion> availableSolutionTemplateVersions = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties SolutionTemplateProperties(string description = null, System.Collections.Generic.IEnumerable<string> capabilities = null, string latestVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState?), bool? enableExternalValidation = default(bool?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties SolutionTemplateVersionProperties(string configurations = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType? orchestratorType = default(Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType SolutionTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData solutionTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties SolutionVersionProperties(string solutionTemplateVersionId = null, int? revision = default(int?), string targetDisplayName = null, string configuration = null, string targetLevelConfiguration = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, string reviewId = null, string externalValidationId = null, Azure.ResourceManager.WorkloadOrchestration.Models.State? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.State?), string solutionInstanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency> solutionDependencies = null, Azure.ResponseError errorDetails = null, System.Uri latestActionTrackingUri = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobType? actionType = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobType?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot SolutionVersionSnapshot(Azure.Core.ResourceIdentifier solutionVersionId = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> specification = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus StageStatus(int? status = default(int?), string statusMessage = null, string stage = null, string nextstage = null, string errorMessage = null, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? isActive = default(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState?), System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> inputs = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> outputs = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties TargetProperties(string description = null, string displayName = null, Azure.Core.ResourceIdentifier contextId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> targetSpecification = null, System.Collections.Generic.IEnumerable<string> capabilities = null, string hierarchyLevel = null, Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus status = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot TargetSnapshot(Azure.Core.ResourceIdentifier targetId = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> targetSpecification = null, string solutionScope = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus TargetStatus(string name = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus> componentStatuses = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties WorkflowProperties(string workflowTemplateId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties WorkflowVersionProperties(int? revision = default(int?), string configuration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec> stageSpec = null, string reviewId = null, Azure.ResourceManager.WorkloadOrchestration.Models.State? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.State?), System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult WorkloadOrchestrationRemoveVersionResult(string status = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent WorkloadOrchestrationSolutionTemplateContent(string solutionTemplateVersionId = null, string solutionInstanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent> solutionDependencies = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent WorkloadOrchestrationUninstallSolutionContent(string solutionTemplateId = null, string solutionInstanceName = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent WorkloadOrchestrationUpdateExternalValidationStatusContent(string solutionVersionId = null, Azure.ResponseError errorDetails = null, string externalValidationId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus validationStatus = default(Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus)) { throw null; }
    }
    public partial class AvailableSolutionTemplateVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion>
    {
        internal AvailableSolutionTemplateVersion() { }
        public bool IsConfigured { get { throw null; } }
        public string LatestConfigRevision { get { throw null; } }
        public string SolutionTemplateVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerCommonTypesExtendedLocation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation>
    {
        public AzureResourceManagerCommonTypesExtendedLocation(string name, Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType extendedLocationType) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType ExtendedLocationType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.AzureResourceManagerCommonTypesExtendedLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkDeployTargetDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails>
    {
        public BulkDeployTargetDetails(Azure.Core.ResourceIdentifier solutionVersionId) { }
        public Azure.Core.ResourceIdentifier SolutionVersionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BulkPublishTargetDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails>
    {
        public BulkPublishTargetDetails(Azure.Core.ResourceIdentifier targetId) { }
        public string SolutionInstanceName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Capability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.Capability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Capability>
    {
        public Capability(string name, string description) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.Capability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.Capability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.Capability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.Capability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Capability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Capability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Capability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComponentStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus>
    {
        internal ComponentStatus() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties>
    {
        public ConfigTemplateProperties(string description) { }
        public string Description { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigTemplateVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties>
    {
        public ConfigTemplateVersionProperties(string configurations) { }
        public string Configurations { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigTemplateVersionWithUpdateType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>
    {
        public ConfigTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData configTemplateVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData ConfigTemplateVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationModel : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationModel(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel Application { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel Common { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel left, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel left, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfigurationType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType Hierarchy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType left, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType left, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContextProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties>
    {
        public ContextProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.Capability> capabilities, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy> hierarchies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.Capability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy> Hierarchies { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContextUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties>
    {
        public ContextUpdateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.Capability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy> Hierarchies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeployJobStepStatistics : Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>
    {
        public DeployJobStepStatistics() { }
        public int? FailedCount { get { throw null; } set { } }
        public int? SuccessCount { get { throw null; } set { } }
        public int? TotalCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus>
    {
        internal DeploymentStatus() { }
        public int? Deployed { get { throw null; } }
        public int? ExpectedRunningJobId { get { throw null; } }
        public int? Generation { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public int? RunningJobId { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus> TargetStatuses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynamicSchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties>
    {
        public DynamicSchemaProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel? ConfigurationModel { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType? ConfigurationType { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeConfigTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch>
    {
        public EdgeConfigTemplatePatch() { }
        public string ConfigTemplateUpdateDescription { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeContextPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>
    {
        public EdgeContextPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeploymentInstancePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch>
    {
        public EdgeDeploymentInstancePatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDiagnosticPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>
    {
        public EdgeDiagnosticPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDynamicSchemaPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch>
    {
        public EdgeDynamicSchemaPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDynamicSchemaVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch>
    {
        public EdgeDynamicSchemaVersionPatch() { }
        public string SchemaVersionPropertiesUpdateValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeExecutionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch>
    {
        public EdgeExecutionPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>
    {
        public EdgeSchemaPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch>
    {
        public EdgeSchemaVersionPatch() { }
        public string SchemaVersionPropertiesUpdateValue { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSiteReferencePatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch>
    {
        public EdgeSiteReferencePatch() { }
        public string SiteId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferencePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>
    {
        public EdgeSolutionPatch() { }
        public System.BinaryData Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>
    {
        public EdgeSolutionTemplatePatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch>
    {
        public EdgeSolutionVersionPatch() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SolutionVersionPropertiesUpdateSpecification { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTargetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>
    {
        public EdgeTargetPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch>
    {
        public EdgeWorkflowPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowVersionPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch>
    {
        public EdgeWorkflowVersionPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ErrorAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction>
    {
        public ErrorAction() { }
        public int? MaxToleratedFailures { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode? Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorActionMode : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorActionMode(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode SilentlyContinue { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode StopOnAnyFailure { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode StopOnNFailures { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode left, Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode left, Azure.ResourceManager.WorkloadOrchestration.Models.ErrorActionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExecutionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties>
    {
        public ExecutionProperties(string workflowVersionId) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus Status { get { throw null; } }
        public string WorkflowVersionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate>
    {
        public ExecutionPropertiesUpdate() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public string WorkflowVersionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus>
    {
        internal ExecutionStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus> StageHistory { get { throw null; } }
        public int? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public System.DateTimeOffset? UpdateOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType CustomLocation { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType left, Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType left, Azure.ResourceManager.WorkloadOrchestration.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Hierarchy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy>
    {
        public Hierarchy(string name, string description) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>
    {
        public InstanceHistoryProperties(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot solutionVersion, Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot target) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? ActiveState { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties ReconciliationPolicy { get { throw null; } }
        public string SolutionScope { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot SolutionVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus Status { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties>
    {
        public InstanceProperties(string solutionVersionId, string targetId) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? ActiveState { get { throw null; } set { } }
        public long? DeploymentTimestampEpoch { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties ReconciliationPolicy { get { throw null; } set { } }
        public string SolutionScope { get { throw null; } set { } }
        public string SolutionVersionId { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus Status { get { throw null; } }
        public string TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstancePropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate>
    {
        public InstancePropertiesUpdate() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? ActiveState { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate ReconciliationPolicy { get { throw null; } set { } }
        public string SolutionScope { get { throw null; } set { } }
        public string SolutionVersionId { get { throw null; } set { } }
        public string TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstancePropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class JobParameterBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase>
    {
        protected JobParameterBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties>
    {
        public JobProperties(Azure.ResourceManager.WorkloadOrchestration.Models.JobType jobType, Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus status) { }
        public string CorrelationId { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase JobParameter { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobType JobType { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> Steps { get { throw null; } }
        public string TriggeredBy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobStatus : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobStatus(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class JobStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep>
    {
        public JobStep(string name, Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus status) { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public string Message { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase Statistics { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> Steps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class JobStepStatisticsBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase>
    {
        protected JobStepStatisticsBase() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JobType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.JobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JobType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobType Deploy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobType ExternalValidation { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobType Staging { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.JobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.JobType left, Azure.ResourceManager.WorkloadOrchestration.Models.JobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.JobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.JobType left, Azure.ResourceManager.WorkloadOrchestration.Models.JobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OrchestratorType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OrchestratorType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType TO { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType left, Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType left, Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState Initialized { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState Inprogress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState left, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState left, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReconciliationPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties>
    {
        public ReconciliationPolicyProperties(Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState state, string interval) { }
        public string Interval { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReconciliationPolicyPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate>
    {
        public ReconciliationPolicyPropertiesUpdate() { }
        public string Interval { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReconciliationState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReconciliationState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState left, Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState left, Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResolvedConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>
    {
        internal ResolvedConfiguration() { }
        public string Configuration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState left, Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState left, Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties>
    {
        public SchemaProperties() { }
        public string CurrentVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>
    {
        public SchemaReferenceProperties(string schemaId) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties>
    {
        public SchemaVersionProperties(string value) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaVersionWithUpdateType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType>
    {
        public SchemaVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData schemaVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties>
    {
        public SiteReferenceProperties(string siteId) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SiteId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency>
    {
        internal SolutionDependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency> Dependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } }
        public string SolutionTemplateVersionId { get { throw null; } }
        public string SolutionVersionId { get { throw null; } }
        public string TargetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties>
    {
        public SolutionProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion> AvailableSolutionTemplateVersions { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionTemplateId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties>
    {
        public SolutionTemplateProperties(string description, System.Collections.Generic.IEnumerable<string> capabilities) { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? EnableExternalValidation { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTemplateUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties>
    {
        public SolutionTemplateUpdateProperties() { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? EnableExternalValidation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTemplateVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties>
    {
        public SolutionTemplateVersionProperties(string configurations, System.Collections.Generic.IDictionary<string, System.BinaryData> specification) { }
        public string Configurations { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType? OrchestratorType { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTemplateVersionWithUpdateType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>
    {
        public SolutionTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData solutionTemplateVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData SolutionTemplateVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>
    {
        public SolutionVersionProperties(System.Collections.Generic.IDictionary<string, System.BinaryData> specification) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobType? ActionType { get { throw null; } }
        public string Configuration { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public string ExternalValidationId { get { throw null; } }
        public System.Uri LatestActionTrackingUri { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency> SolutionDependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } }
        public string SolutionTemplateVersionId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.State? State { get { throw null; } }
        public string TargetDisplayName { get { throw null; } }
        public string TargetLevelConfiguration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionVersionSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot>
    {
        internal SolutionVersionSnapshot() { }
        public Azure.Core.ResourceIdentifier SolutionVersionId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Specification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StageSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec>
    {
        public StageSpec(string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig TaskOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec> Tasks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus>
    {
        internal StageStatus() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Inputs { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? IsActive { get { throw null; } }
        public string Nextstage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Outputs { get { throw null; } }
        public string Stage { get { throw null; } }
        public int? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct State : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.State>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public State(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State Deployed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State Deploying { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State ExternalValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State InReview { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State PendingExternalValidation { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State ReadyToDeploy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State ReadyToUpgrade { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State Staging { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State Undeployed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.State UpgradeInReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.State other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.State left, Azure.ResourceManager.WorkloadOrchestration.Models.State right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.State (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.State left, Azure.ResourceManager.WorkloadOrchestration.Models.State right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties>
    {
        public TargetProperties(string description, string displayName, Azure.Core.ResourceIdentifier contextId, System.Collections.Generic.IDictionary<string, System.BinaryData> targetSpecification, System.Collections.Generic.IEnumerable<string> capabilities, string hierarchyLevel) { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public Azure.Core.ResourceIdentifier ContextId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string HierarchyLevel { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionScope { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? State { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> TargetSpecification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot>
    {
        internal TargetSnapshot() { }
        public string SolutionScope { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> TargetSpecification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus>
    {
        internal TargetStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus> ComponentStatuses { get { throw null; } }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties>
    {
        public TargetUpdateProperties() { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public Azure.Core.ResourceIdentifier ContextId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string HierarchyLevel { get { throw null; } set { } }
        public string SolutionScope { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? State { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> TargetSpecification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec>
    {
        public TaskSpec(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> specification) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpdateType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpdateType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType Major { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType Minor { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType Patch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType left, Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType left, Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ValidationStatus : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkflowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties>
    {
        public WorkflowProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string WorkflowTemplateId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties>
    {
        public WorkflowVersionProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec> stageSpec) { }
        public string Configuration { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec> StageSpec { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.State? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowVersionPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate>
    {
        public WorkflowVersionPropertiesUpdate() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec> StageSpec { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationBulkDeploySolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent>
    {
        public WorkloadOrchestrationBulkDeploySolutionContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails> targets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails> Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkDeploySolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationBulkPublishSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent>
    {
        public WorkloadOrchestrationBulkPublishSolutionContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails> targets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent> SolutionDependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails> Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationBulkPublishSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationDeployJobContent : Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent>
    {
        public WorkloadOrchestrationDeployJobContent() { }
        public string ParameterSolutionVersionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationDeployJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationInstallSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent>
    {
        public WorkloadOrchestrationInstallSolutionContent(string solutionVersionId) { }
        public string SolutionVersionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationInstallSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationRemoveRevisionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent>
    {
        public WorkloadOrchestrationRemoveRevisionContent(string solutionTemplateId, string solutionVersion) { }
        public string SolutionTemplateId { get { throw null; } }
        public string SolutionVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveRevisionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationRemoveVersionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>
    {
        internal WorkloadOrchestrationRemoveVersionResult() { }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationRemoveVersionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationSolutionDependencyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent>
    {
        public WorkloadOrchestrationSolutionDependencyContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent> Dependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public string SolutionTemplateId { get { throw null; } set { } }
        public string SolutionTemplateVersion { get { throw null; } set { } }
        public string SolutionVersionId { get { throw null; } set { } }
        public string TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationSolutionTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent>
    {
        public WorkloadOrchestrationSolutionTemplateContent(string solutionTemplateVersionId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionDependencyContent> SolutionDependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public string SolutionTemplateVersionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationSolutionVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent>
    {
        public WorkloadOrchestrationSolutionVersionContent(string solutionVersionId) { }
        public string SolutionVersionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationSolutionVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationTaskConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig>
    {
        public WorkloadOrchestrationTaskConfig() { }
        public int? Concurrency { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction ErrorAction { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationTaskConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationUninstallSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent>
    {
        public WorkloadOrchestrationUninstallSolutionContent(string solutionTemplateId) { }
        public string SolutionInstanceName { get { throw null; } set { } }
        public string SolutionTemplateId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUninstallSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationUpdateExternalValidationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent>
    {
        public WorkloadOrchestrationUpdateExternalValidationStatusContent(string solutionVersionId, string externalValidationId, Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus validationStatus) { }
        public Azure.ResponseError ErrorDetails { get { throw null; } set { } }
        public string ExternalValidationId { get { throw null; } }
        public string SolutionVersionId { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationUpdateExternalValidationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadOrchestrationVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent>
    {
        public WorkloadOrchestrationVersionContent(string version) { }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
