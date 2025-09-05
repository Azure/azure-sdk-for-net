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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult> RemoveVersion(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>> RemoveVersionAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties Properties { get { throw null; } set { } }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties Properties { get { throw null; } set { } }
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
        internal EdgeDeploymentInstanceHistoryData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties Properties { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? EdgeDiagnosticProvisioningState { get { throw null; } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource> Update(Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource> Update(Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        internal EdgeJobData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties Properties { get { throw null; } }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties Properties { get { throw null; } set { } }
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
        internal EdgeSchemaReferenceData() { }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties Properties { get { throw null; } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult> RemoveVersion(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>> RemoveVersionAsync(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource> Update(Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties Properties { get { throw null; } set { } }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource> GetEdgeSolutionTemplateVersion(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionResource>> GetEdgeSolutionTemplateVersionAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionCollection GetEdgeSolutionTemplateVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation BulkDeploySolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BulkDeploySolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BulkPublishSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BulkPublishSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation InstallSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InstallSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> PublishSolutionVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> PublishSolutionVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveRevision(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveRevisionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration> ResolveConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>> ResolveConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> ReviewSolutionVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> ReviewSolutionVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UninstallSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UninstallSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeTargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource> UpdateExternalValidationStatus(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionResource>> UpdateExternalValidationStatusAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public static partial class ArmWorkloadOrchestrationModelFactory
    {
        public static Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion AvailableSolutionTemplateVersion(string solutionTemplateVersion = null, string latestConfigRevision = null, bool isConfigured = false) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails BulkPublishTargetDetails(Azure.Core.ResourceIdentifier targetId = null, string solutionInstanceName = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType ConfigTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData configTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent DeployJobContent(Azure.Core.ResourceIdentifier parameterSolutionVersionId = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics DeployJobStepStatistics(int? totalCount = default(int?), int? successCount = default(int?), int? failedCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateData EdgeConfigTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties EdgeConfigTemplateProperties(string description = null, string latestVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData EdgeConfigTemplateVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties EdgeConfigTemplateVersionProperties(string configurations = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeContextData EdgeContextData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties EdgeContextProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy> hierarchies = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceData EdgeDeploymentInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDeploymentInstanceHistoryData EdgeDeploymentInstanceHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties EdgeDeploymentInstanceHistoryProperties(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot solutionVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot target = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState? activeState = default(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState?), Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy reconciliationPolicy = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus status = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties EdgeDeploymentInstanceProperties(string solutionVersionId = null, string targetId = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState? activeState = default(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState?), Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy reconciliationPolicy = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus status = null, long? deploymentTimestampEpoch = default(long?), Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus EdgeDeploymentStatus(System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), int? deployed = default(int?), int? expectedRunningJobId = default(int?), int? runningJobId = default(int?), string status = null, string statusDetails = null, int? generation = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus> targetStatuses = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDiagnosticData EdgeDiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? edgeDiagnosticProvisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaData EdgeDynamicSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties EdgeDynamicSchemaProperties(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType? configurationType = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType?), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType? configurationModel = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType?), Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeDynamicSchemaVersionData EdgeDynamicSchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeExecutionData EdgeExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties EdgeExecutionProperties(string workflowVersionId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus status = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus EdgeExecutionStageStatus(int? status = default(int?), string statusMessage = null, string stage = null, string nextstage = null, string errorMessage = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState? isActive = default(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState?), System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> inputs = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> outputs = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus EdgeExecutionStatus(System.DateTimeOffset? updateOn = default(System.DateTimeOffset?), int? status = default(int?), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus> stageHistory = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeJobData EdgeJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties EdgeJobProperties(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType jobType = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus status = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent jobParameter = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep> steps = null, string triggeredBy = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep EdgeJobStep(string name = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus status = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string message = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics statistics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep> steps = null, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaData EdgeSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties EdgeSchemaProperties(string currentVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaReferenceData EdgeSchemaReferenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties EdgeSchemaReferenceProperties(string schemaId = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData EdgeSchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties EdgeSchemaVersionProperties(string value = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType EdgeSchemaVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSiteReferenceData EdgeSiteReferenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties EdgeSiteReferenceProperties(string siteId = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionData EdgeSolutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency EdgeSolutionDependency(Azure.Core.ResourceIdentifier solutionVersionId = null, string solutionInstanceName = null, Azure.Core.ResourceIdentifier solutionTemplateVersionId = null, Azure.Core.ResourceIdentifier targetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency> dependencies = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties EdgeSolutionProperties(string solutionTemplateId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion> availableSolutionTemplateVersions = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent EdgeSolutionTemplateContent(Azure.Core.ResourceIdentifier solutionTemplateVersionId = null, string solutionInstanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent> solutionDependencies = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateData EdgeSolutionTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties EdgeSolutionTemplateProperties(string description = null, System.Collections.Generic.IEnumerable<string> capabilities = null, string latestVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState?), bool? isExternalValidationEnabled = default(bool?), Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData EdgeSolutionTemplateVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties EdgeSolutionTemplateVersionProperties(string configurations = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType? orchestratorType = default(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType?), Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType EdgeSolutionTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData solutionTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionVersionData EdgeSolutionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties EdgeSolutionVersionProperties(string solutionTemplateVersionId = null, int? revision = default(int?), string targetDisplayName = null, string configuration = null, string targetLevelConfiguration = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, string reviewId = null, string externalValidationId = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState?), string solutionInstanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency> solutionDependencies = null, Azure.ResponseError errorDetails = null, string latestActionTrackingUri = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType? actionType = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType?), Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeTargetData EdgeTargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties properties = null, Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties EdgeTargetProperties(string description = null, string displayName = null, Azure.Core.ResourceIdentifier contextId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> targetSpecification = null, System.Collections.Generic.IEnumerable<string> capabilities = null, string hierarchyLevel = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus status = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState?), Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot EdgeTargetSnapshot(Azure.Core.ResourceIdentifier targetId = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> targetSpecification = null, string solutionScope = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus EdgeTargetStatus(string name = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus> componentStatuses = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowData EdgeWorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties EdgeWorkflowProperties(string workflowTemplateId = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.EdgeWorkflowVersionData EdgeWorkflowVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties EdgeWorkflowVersionProperties(int? revision = default(int?), string configuration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec> stageSpec = null, string reviewId = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState?), System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult RemoveVersionResult(string status = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration ResolvedConfiguration(string configuration = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot SolutionVersionSnapshot(Azure.Core.ResourceIdentifier solutionVersionId = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> specification = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus TargetComponentStatus(string name = null, string status = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent UninstallSolutionContent(Azure.Core.ResourceIdentifier solutionTemplateId = null, string solutionInstanceName = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent UpdateExternalValidationStatusContent(Azure.Core.ResourceIdentifier solutionVersionId = null, Azure.ResponseError errorDetails = null, string externalValidationId = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus validationStatus = default(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus)) { throw null; }
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
    public partial class BulkDeploySolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent>
    {
        public BulkDeploySolutionContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails> targets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeployTargetDetails> Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class BulkPublishSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent>
    {
        public BulkPublishSolutionContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails> targets) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent> SolutionDependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishTargetDetails> Targets { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class ConfigTemplateVersionWithUpdateType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>
    {
        public ConfigTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData configTemplateVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.EdgeConfigTemplateVersionData ConfigTemplateVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType? UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContextCapability : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability>
    {
        public ContextCapability(string name, string description) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContextHierarchy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy>
    {
        public ContextHierarchy(string name, string description) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeployJobContent : Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>
    {
        internal DeployJobContent() { }
        public Azure.Core.ResourceIdentifier ParameterSolutionVersionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeployJobStepStatistics : Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>
    {
        internal DeployJobStepStatistics() { }
        public int? FailedCount { get { throw null; } }
        public int? SuccessCount { get { throw null; } }
        public int? TotalCount { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class EdgeConfigTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties>
    {
        public EdgeConfigTemplateProperties(string description) { }
        public string Description { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeConfigTemplateVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties>
    {
        public EdgeConfigTemplateVersionProperties(string configurations) { }
        public string Configurations { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeConfigTemplateVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeContextPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>
    {
        public EdgeContextPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeContextPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties>
    {
        public EdgeContextPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy> Hierarchies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeContextProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties>
    {
        public EdgeContextProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability> capabilities, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy> hierarchies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.ContextCapability> Capabilities { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.ContextHierarchy> Hierarchies { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeContextProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeploymentInstanceHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties>
    {
        internal EdgeDeploymentInstanceHistoryProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState? ActiveState { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy ReconciliationPolicy { get { throw null; } }
        public string SolutionScope { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot SolutionVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus Status { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeploymentInstanceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties>
    {
        public EdgeDeploymentInstanceProperties(string solutionVersionId, string targetId) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState? ActiveState { get { throw null; } set { } }
        public long? DeploymentTimestampEpoch { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy ReconciliationPolicy { get { throw null; } set { } }
        public string SolutionScope { get { throw null; } set { } }
        public string SolutionVersionId { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus Status { get { throw null; } }
        public string TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentInstanceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDeploymentStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus>
    {
        internal EdgeDeploymentStatus() { }
        public int? Deployed { get { throw null; } }
        public int? ExpectedRunningJobId { get { throw null; } }
        public int? Generation { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public int? RunningJobId { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus> TargetStatuses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDiagnosticPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>
    {
        public EdgeDiagnosticPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDiagnosticPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties>
    {
        public EdgeDiagnosticPatchProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDiagnosticPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeDynamicSchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties>
    {
        public EdgeDynamicSchemaProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType? ConfigurationModel { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType? ConfigurationType { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDynamicSchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeExecutionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties>
    {
        public EdgeExecutionProperties(string workflowVersionId) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus Status { get { throw null; } }
        public string WorkflowVersionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeExecutionStageStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus>
    {
        internal EdgeExecutionStageStatus() { }
        public string ErrorMessage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Inputs { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState? IsActive { get { throw null; } }
        public string Nextstage { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> Outputs { get { throw null; } }
        public string Stage { get { throw null; } }
        public int? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeExecutionStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus>
    {
        internal EdgeExecutionStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStageStatus> StageHistory { get { throw null; } }
        public int? Status { get { throw null; } }
        public string StatusMessage { get { throw null; } }
        public System.DateTimeOffset? UpdateOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeExecutionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EdgeJobContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent>
    {
        protected EdgeJobContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties>
    {
        internal EdgeJobProperties() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobContent JobParameter { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType JobType { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep> Steps { get { throw null; } }
        public string TriggeredBy { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeJobStatus : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeJobStatus(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus NotStarted { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeJobStep : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep>
    {
        internal EdgeJobStep() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics Statistics { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep> Steps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EdgeJobStepStatistics : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics>
    {
        protected EdgeJobStepStatistics() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobStepStatistics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeJobType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeJobType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType Deploy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType ExternalValidation { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType Staging { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeResourceState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeResourceState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeSchemaConfigurationModelType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeSchemaConfigurationModelType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType Application { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType Common { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationModelType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeSchemaConfigurationType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeSchemaConfigurationType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType Hierarchy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType Shared { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeSchemaPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>
    {
        public EdgeSchemaPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties>
    {
        public EdgeSchemaPatchProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties>
    {
        public EdgeSchemaProperties() { }
        public string CurrentVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties>
    {
        internal EdgeSchemaReferenceProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties>
    {
        public EdgeSchemaVersionProperties(string value) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSchemaVersionWithUpdateType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType>
    {
        public EdgeSchemaVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData schemaVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.EdgeSchemaVersionData SchemaVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType? UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSchemaVersionWithUpdateType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSiteReferenceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties>
    {
        public EdgeSiteReferenceProperties(string siteId) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string SiteId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSiteReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency>
    {
        internal EdgeSolutionDependency() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency> Dependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } }
        public Azure.Core.ResourceIdentifier SolutionTemplateVersionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SolutionVersionId { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionDependencyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent>
    {
        public EdgeSolutionDependencyContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent> Dependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SolutionTemplateId { get { throw null; } set { } }
        public string SolutionTemplateVersion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SolutionVersionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>
    {
        public EdgeSolutionPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties>
    {
        public EdgeSolutionPatchProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties>
    {
        public EdgeSolutionProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion> AvailableSolutionTemplateVersions { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionTemplateId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent>
    {
        public EdgeSolutionTemplateContent(Azure.Core.ResourceIdentifier solutionTemplateVersionId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependencyContent> SolutionDependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SolutionTemplateVersionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>
    {
        public EdgeSolutionTemplatePatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplatePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties>
    {
        public EdgeSolutionTemplatePatchProperties() { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsExternalValidationEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplatePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties>
    {
        public EdgeSolutionTemplateProperties(string description, System.Collections.Generic.IEnumerable<string> capabilities) { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsExternalValidationEnabled { get { throw null; } set { } }
        public string LatestVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState? State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplateVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties>
    {
        public EdgeSolutionTemplateVersionProperties(string configurations, System.Collections.Generic.IDictionary<string, System.BinaryData> specification) { }
        public string Configurations { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType? OrchestratorType { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionTemplateVersionWithUpdateType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType>
    {
        public EdgeSolutionTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData solutionTemplateVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.EdgeSolutionTemplateVersionData SolutionTemplateVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType? UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionTemplateVersionWithUpdateType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent>
    {
        public EdgeSolutionVersionContent(Azure.Core.ResourceIdentifier solutionVersionId) { }
        public Azure.Core.ResourceIdentifier SolutionVersionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeSolutionVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties>
    {
        public EdgeSolutionVersionProperties(System.Collections.Generic.IDictionary<string, System.BinaryData> specification) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeJobType? ActionType { get { throw null; } }
        public string Configuration { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public string ExternalValidationId { get { throw null; } }
        public string LatestActionTrackingUri { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionDependency> SolutionDependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } }
        public string SolutionTemplateVersionId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState? State { get { throw null; } }
        public string TargetDisplayName { get { throw null; } }
        public string TargetLevelConfiguration { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeSolutionVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTargetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>
    {
        public EdgeTargetPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTargetPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties>
    {
        public EdgeTargetPatchProperties() { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public Azure.Core.ResourceIdentifier ContextId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string HierarchyLevel { get { throw null; } set { } }
        public string SolutionScope { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState? State { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> TargetSpecification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTargetProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties>
    {
        public EdgeTargetProperties(string description, string displayName, Azure.Core.ResourceIdentifier contextId, System.Collections.Generic.IDictionary<string, System.BinaryData> targetSpecification, System.Collections.Generic.IEnumerable<string> capabilities, string hierarchyLevel) { }
        public System.Collections.Generic.IList<string> Capabilities { get { throw null; } }
        public Azure.Core.ResourceIdentifier ContextId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string HierarchyLevel { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string SolutionScope { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeResourceState? State { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeDeploymentStatus Status { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> TargetSpecification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTargetSnapshot : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot>
    {
        internal EdgeTargetSnapshot() { }
        public string SolutionScope { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> TargetSpecification { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetSnapshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeTargetStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus>
    {
        internal EdgeTargetStatus() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus> ComponentStatuses { get { throw null; } }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeTargetStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EdgeUpdateType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EdgeUpdateType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType Major { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType Minor { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType Patch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType left, Azure.ResourceManager.WorkloadOrchestration.Models.EdgeUpdateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EdgeVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent>
    {
        public EdgeVersionContent(string version) { }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties>
    {
        public EdgeWorkflowProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string WorkflowTemplateId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowStageSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec>
    {
        public EdgeWorkflowStageSpec(string name) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig TaskOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec> Tasks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowTaskConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig>
    {
        public EdgeWorkflowTaskConfig() { }
        public int? Concurrency { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction ErrorAction { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowTaskSpec : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec>
    {
        public EdgeWorkflowTaskSpec(string name, System.Collections.Generic.IDictionary<string, System.BinaryData> specification) { }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowTaskSpec>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EdgeWorkflowVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties>
    {
        public EdgeWorkflowVersionProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec> stageSpec) { }
        public string Configuration { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReviewId { get { throw null; } }
        public int? Revision { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Specification { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowStageSpec> StageSpec { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState? State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.EdgeWorkflowVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstallSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>
    {
        public InstallSolutionContent(Azure.Core.ResourceIdentifier solutionVersionId) { }
        public Azure.Core.ResourceIdentifier SolutionVersionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceActiveState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceActiveState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState left, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState left, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceActiveState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InstanceReconciliationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy>
    {
        public InstanceReconciliationPolicy(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState state, string interval) { }
        public string Interval { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState State { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InstanceReconciliationState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InstanceReconciliationState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState Active { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState Inactive { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState left, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState left, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceReconciliationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoveRevisionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>
    {
        public RemoveRevisionContent(Azure.Core.ResourceIdentifier solutionTemplateId, string solutionVersion) { }
        public Azure.Core.ResourceIdentifier SolutionTemplateId { get { throw null; } }
        public string SolutionVersion { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoveVersionResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>
    {
        internal RemoveVersionResult() { }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public readonly partial struct SolutionInstanceState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SolutionInstanceState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState Deployed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState Deploying { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState ExternalValidationFailed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState InReview { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState PendingExternalValidation { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState ReadyToDeploy { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState ReadyToUpgrade { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState Staging { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState Undeployed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState UpgradeInReview { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState left, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState left, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SolutionInstanceValidationStatus : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SolutionInstanceValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus Valid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus left, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SolutionVersionOrchestratorType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SolutionVersionOrchestratorType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType TO { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType left, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType left, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionOrchestratorType right) { throw null; }
        public override string ToString() { throw null; }
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
    public partial class TargetComponentStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus>
    {
        internal TargetComponentStatus() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetComponentStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskErrorAction : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction>
    {
        public TaskErrorAction() { }
        public int? MaxToleratedFailures { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType? Mode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskErrorActionModeType : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskErrorActionModeType(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType SilentlyContinue { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType StopOnAnyFailure { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType StopOnNFailures { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType left, Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType left, Azure.ResourceManager.WorkloadOrchestration.Models.TaskErrorActionModeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UninstallSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>
    {
        public UninstallSolutionContent(Azure.Core.ResourceIdentifier solutionTemplateId) { }
        public string SolutionInstanceName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SolutionTemplateId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateExternalValidationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>
    {
        public UpdateExternalValidationStatusContent(Azure.Core.ResourceIdentifier solutionVersionId, string externalValidationId, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus validationStatus) { }
        public Azure.ResponseError ErrorDetails { get { throw null; } set { } }
        public string ExternalValidationId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SolutionVersionId { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionInstanceValidationStatus ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadOrchestrationProvisioningState : System.IEquatable<Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadOrchestrationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState Initialized { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState Inprogress { get { throw null; } }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState left, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState left, Azure.ResourceManager.WorkloadOrchestration.Models.WorkloadOrchestrationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
