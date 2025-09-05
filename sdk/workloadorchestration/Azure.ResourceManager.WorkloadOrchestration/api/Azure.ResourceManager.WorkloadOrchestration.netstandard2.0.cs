namespace Azure.ResourceManager.WorkloadOrchestration
{
    public partial class AzureResourceManagerWorkloadOrchestrationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerWorkloadOrchestrationContext() { }
        public static Azure.ResourceManager.WorkloadOrchestration.AzureResourceManagerWorkloadOrchestrationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class ConfigTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>, System.Collections.IEnumerable
    {
        protected ConfigTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string configTemplateName, Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string configTemplateName, Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> Get(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> GetAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetIfExists(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> GetIfExistsAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>
    {
        public ConfigTemplateData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigTemplateResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> GetConfigTemplateVersion(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>> GetConfigTemplateVersionAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionCollection GetConfigTemplateVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult> RemoveVersion(Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>> RemoveVersionAsync(Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfigTemplateVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>, System.Collections.IEnumerable
    {
        protected ConfigTemplateVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> Get(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>> GetAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> GetIfExists(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>> GetIfExistsAsync(string configTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfigTemplateVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>
    {
        public ConfigTemplateVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfigTemplateVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfigTemplateVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string configTemplateName, string configTemplateVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContextCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ContextResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ContextResource>, System.Collections.IEnumerable
    {
        protected ContextCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ContextResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string contextName, Azure.ResourceManager.WorkloadOrchestration.ContextData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string contextName, Azure.ResourceManager.WorkloadOrchestration.ContextData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource> Get(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> GetAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetIfExists(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> GetIfExistsAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.ContextResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ContextResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.ContextResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ContextResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ContextData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>
    {
        public ContextData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ContextData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ContextData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContextResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ContextResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ContextData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> GetSiteReference(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>> GetSiteReferenceAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SiteReferenceCollection GetSiteReferences() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> GetWorkflow(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>> GetWorkflowAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.WorkflowCollection GetWorkflows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.ContextData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ContextData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ContextData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ContextResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiagnosticCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>, System.Collections.IEnumerable
    {
        protected DiagnosticCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diagnosticName, Azure.ResourceManager.WorkloadOrchestration.DiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diagnosticName, Azure.ResourceManager.WorkloadOrchestration.DiagnosticData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> Get(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> GetAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetIfExists(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> GetIfExistsAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiagnosticData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>
    {
        public DiagnosticData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? DiagnosticProvisioningState { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiagnosticResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiagnosticResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DiagnosticData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diagnosticName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.DiagnosticData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DiagnosticData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DiagnosticData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DynamicSchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>, System.Collections.IEnumerable
    {
        protected DynamicSchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dynamicSchemaName, Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dynamicSchemaName, Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> Get(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>> GetAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> GetIfExists(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>> GetIfExistsAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DynamicSchemaData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>
    {
        public DynamicSchemaData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynamicSchemaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DynamicSchemaResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName, string dynamicSchemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> GetDynamicSchemaVersion(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>> GetDynamicSchemaVersionAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionCollection GetDynamicSchemaVersions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> Update(Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DynamicSchemaVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>, System.Collections.IEnumerable
    {
        protected DynamicSchemaVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string dynamicSchemaVersionName, Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string dynamicSchemaVersionName, Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> Get(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>> GetAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> GetIfExists(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>> GetIfExistsAsync(string dynamicSchemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DynamicSchemaVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>
    {
        public DynamicSchemaVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DynamicSchemaVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DynamicSchemaVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName, string dynamicSchemaName, string dynamicSchemaVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource> Update(Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExecutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>, System.Collections.IEnumerable
    {
        protected ExecutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string executionName, Azure.ResourceManager.WorkloadOrchestration.ExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string executionName, Azure.ResourceManager.WorkloadOrchestration.ExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> Get(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>> GetAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> GetIfExists(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>> GetIfExistsAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ExecutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>
    {
        public ExecutionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ExecutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ExecutionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ExecutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string workflowName, string versionName, string executionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.ExecutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.ExecutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.ExecutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.ExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.ExecutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class InstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>, System.Collections.IEnumerable
    {
        protected InstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.WorkloadOrchestration.InstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.WorkloadOrchestration.InstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> Get(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>> GetAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> GetIfExists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>> GetIfExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InstanceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>
    {
        public InstanceData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.InstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.InstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceHistoryCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>, System.Collections.IEnumerable
    {
        protected InstanceHistoryCollection() { }
        public virtual Azure.Response<bool> Exists(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> Get(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>> GetAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> GetIfExists(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>> GetIfExistsAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class InstanceHistoryData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>
    {
        internal InstanceHistoryData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceHistoryResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstanceHistoryResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName, string instanceName, string instanceHistoryName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected InstanceResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.InstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName, string instanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryCollection GetInstanceHistories() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource> GetInstanceHistory(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource>> GetInstanceHistoryAsync(string instanceHistoryName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.InstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.InstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.InstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.InstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.InstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class JobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.JobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.JobResource>, System.Collections.IEnumerable
    {
        protected JobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.JobResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.JobResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.JobResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.JobResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.JobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.JobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.JobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.JobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class JobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.JobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>
    {
        internal JobData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.JobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.JobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class JobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.JobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected JobResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.JobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.JobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.JobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.JobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>, System.Collections.IEnumerable
    {
        protected SchemaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.WorkloadOrchestration.SchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaName, Azure.ResourceManager.WorkloadOrchestration.SchemaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> Get(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> GetAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetIfExists(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> GetIfExistsAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchemaData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>
    {
        public SchemaData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaReferenceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>, System.Collections.IEnumerable
    {
        protected SchemaReferenceCollection() { }
        public virtual Azure.Response<bool> Exists(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> Get(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>> GetAsync(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> GetIfExists(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>> GetIfExistsAsync(string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchemaReferenceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>
    {
        internal SchemaReferenceData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaReferenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SchemaReferenceResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string resourceUri, string schemaReferenceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SchemaResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource> GetDynamicSchema(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource>> GetDynamicSchemaAsync(string dynamicSchemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaCollection GetDynamicSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> GetSchemaVersion(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>> GetSchemaVersionAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaVersionCollection GetSchemaVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult> RemoveVersion(Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult>> RemoveVersionAsync(Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SchemaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SchemaVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>, System.Collections.IEnumerable
    {
        protected SchemaVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string schemaVersionName, Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string schemaVersionName, Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> Get(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>> GetAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> GetIfExists(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>> GetIfExistsAsync(string schemaVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SchemaVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>
    {
        public SchemaVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SchemaVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string schemaName, string schemaVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource> Update(Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SiteReferenceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>, System.Collections.IEnumerable
    {
        protected SiteReferenceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string siteReferenceName, Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string siteReferenceName, Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> Get(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>> GetAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> GetIfExists(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>> GetIfExistsAsync(string siteReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SiteReferenceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>
    {
        public SiteReferenceData() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SiteReferenceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SiteReferenceResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string siteReferenceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>, System.Collections.IEnumerable
    {
        protected SolutionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.WorkloadOrchestration.SolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionName, Azure.ResourceManager.WorkloadOrchestration.SolutionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> Get(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>> GetAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> GetIfExists(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>> GetIfExistsAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SolutionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>
    {
        public SolutionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceResource> GetInstance(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.InstanceResource>> GetInstanceAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.InstanceCollection GetInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> GetSolutionVersion(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> GetSolutionVersionAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionVersionCollection GetSolutionVersions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SolutionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>, System.Collections.IEnumerable
    {
        protected SolutionTemplateCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionTemplateName, Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionTemplateName, Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> Get(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> GetAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetIfExists(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> GetIfExistsAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SolutionTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>
    {
        public SolutionTemplateData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionTemplateResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionTemplateName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> CreateVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>> CreateVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> GetSolutionTemplateVersion(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>> GetSolutionTemplateVersionAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionCollection GetSolutionTemplateVersions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> Update(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> UpdateAsync(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SolutionTemplateVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>, System.Collections.IEnumerable
    {
        protected SolutionTemplateVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> Get(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>> GetAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> GetIfExists(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>> GetIfExistsAsync(string solutionTemplateVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SolutionTemplateVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>
    {
        public SolutionTemplateVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTemplateVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionTemplateVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation BulkDeploySolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BulkDeploySolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkDeploySolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BulkPublishSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BulkPublishSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.BulkPublishSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string solutionTemplateName, string solutionTemplateVersionName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>, System.Collections.IEnumerable
    {
        protected SolutionVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string solutionVersionName, Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string solutionVersionName, Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> Get(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> GetAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> GetIfExists(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> GetIfExistsAsync(string solutionVersionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SolutionVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>
    {
        public SolutionVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SolutionVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName, string solutionName, string solutionVersionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class TargetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.TargetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.TargetResource>, System.Collections.IEnumerable
    {
        protected TargetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.TargetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.WorkloadOrchestration.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string targetName, Azure.ResourceManager.WorkloadOrchestration.TargetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource> Get(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> GetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetIfExists(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> GetIfExistsAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.TargetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.TargetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.TargetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.TargetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class TargetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>
    {
        public TargetData(Azure.Core.AzureLocation location) { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.TargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.TargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected TargetResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.TargetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string targetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionResource> GetSolution(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionResource>> GetSolutionAsync(string solutionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionCollection GetSolutions() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation InstallSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> InstallSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> PublishSolutionVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> PublishSolutionVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RemoveRevision(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RemoveRevisionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration> ResolveConfiguration(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration>> ResolveConfigurationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> ReviewSolutionVersion(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> ReviewSolutionVersionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.TargetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.TargetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.TargetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UninstallSolution(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UninstallSolutionAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.TargetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource> UpdateExternalValidationStatus(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource>> UpdateExternalValidationStatusAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>, System.Collections.IEnumerable
    {
        protected WorkflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.WorkloadOrchestration.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.WorkloadOrchestration.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> Get(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>> GetAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> GetIfExists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>> GetIfExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>
    {
        public WorkflowData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.WorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string workflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> GetWorkflowVersion(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>> GetWorkflowVersionAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionCollection GetWorkflowVersions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowVersionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>, System.Collections.IEnumerable
    {
        protected WorkflowVersionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string versionName, Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> Get(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>> GetAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> GetIfExists(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>> GetIfExistsAsync(string versionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowVersionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>
    {
        public WorkflowVersionData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowVersionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowVersionResource() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string contextName, string workflowName, string versionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource> GetExecution(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ExecutionResource>> GetExecutionAsync(string executionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ExecutionCollection GetExecutions() { throw null; }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class WorkloadOrchestrationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetConfigTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> GetConfigTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource GetConfigTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateCollection GetConfigTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetConfigTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetConfigTemplatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource GetConfigTemplateVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetContext(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> GetContextAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ContextResource GetContextResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ContextCollection GetContexts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetContexts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetContextsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetDiagnostic(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> GetDiagnosticAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource GetDiagnosticResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.DiagnosticCollection GetDiagnostics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetDiagnostics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetDiagnosticsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource GetDynamicSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource GetDynamicSchemaVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ExecutionResource GetExecutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource GetInstanceHistoryResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.InstanceResource GetInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource> GetJob(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource>> GetJobAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.JobResource GetJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.JobCollection GetJobs(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetSchema(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> GetSchemaAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> GetSchemaReference(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>> GetSchemaReferenceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource GetSchemaReferenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceCollection GetSchemaReferences(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaResource GetSchemaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaCollection GetSchemas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetSchemas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetSchemasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource GetSchemaVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource GetSiteReferenceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionResource GetSolutionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetSolutionTemplate(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> GetSolutionTemplateAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource GetSolutionTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateCollection GetSolutionTemplates(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetSolutionTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetSolutionTemplatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource GetSolutionTemplateVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource GetSolutionVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetTarget(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> GetTargetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.TargetResource GetTargetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.TargetCollection GetTargets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetTargets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetTargetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.WorkflowResource GetWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource GetWorkflowVersionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.WorkloadOrchestration.Mocking
{
    public partial class MockableWorkloadOrchestrationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadOrchestrationArmClient() { }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource GetConfigTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionResource GetConfigTemplateVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ContextResource GetContextResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource GetDiagnosticResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaResource GetDynamicSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionResource GetDynamicSchemaVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ExecutionResource GetExecutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryResource GetInstanceHistoryResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.InstanceResource GetInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource> GetJob(Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.JobResource>> GetJobAsync(Azure.Core.ResourceIdentifier scope, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.JobResource GetJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.JobCollection GetJobs(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource> GetSchemaReference(Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource>> GetSchemaReferenceAsync(Azure.Core.ResourceIdentifier scope, string schemaReferenceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceResource GetSchemaReferenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceCollection GetSchemaReferences(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaResource GetSchemaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaVersionResource GetSchemaVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SiteReferenceResource GetSiteReferenceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionResource GetSolutionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource GetSolutionTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionResource GetSolutionTemplateVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionVersionResource GetSolutionVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.TargetResource GetTargetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.WorkflowResource GetWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionResource GetWorkflowVersionResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableWorkloadOrchestrationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadOrchestrationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetConfigTemplate(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource>> GetConfigTemplateAsync(string configTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateCollection GetConfigTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetContext(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.ContextResource>> GetContextAsync(string contextName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.ContextCollection GetContexts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetDiagnostic(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource>> GetDiagnosticAsync(string diagnosticName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.DiagnosticCollection GetDiagnostics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetSchema(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SchemaResource>> GetSchemaAsync(string schemaName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SchemaCollection GetSchemas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetSolutionTemplate(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource>> GetSolutionTemplateAsync(string solutionTemplateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateCollection GetSolutionTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetTarget(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.WorkloadOrchestration.TargetResource>> GetTargetAsync(string targetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.WorkloadOrchestration.TargetCollection GetTargets() { throw null; }
    }
    public partial class MockableWorkloadOrchestrationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableWorkloadOrchestrationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetConfigTemplates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateResource> GetConfigTemplatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetContexts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.ContextResource> GetContextsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetDiagnostics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.DiagnosticResource> GetDiagnosticsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetSchemas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SchemaResource> GetSchemasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetSolutionTemplates(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateResource> GetSolutionTemplatesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetTargets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.WorkloadOrchestration.TargetResource> GetTargetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateData ConfigTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateProperties ConfigTemplateProperties(string description = null, string latestVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData ConfigTemplateVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionProperties ConfigTemplateVersionProperties(string configurations = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplateVersionWithUpdateType ConfigTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData configTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ContextData ContextData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ContextProperties ContextProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.Capability> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.Hierarchy> hierarchies = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent DeployJobContent(string parameterSolutionVersionId = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics DeployJobStepStatistics(int? totalCount = default(int?), int? successCount = default(int?), int? failedCount = default(int?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus DeploymentStatus(System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), int? deployed = default(int?), int? expectedRunningJobId = default(int?), int? runningJobId = default(int?), string status = null, string statusDetails = null, int? generation = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus> targetStatuses = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.DiagnosticData DiagnosticData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? diagnosticProvisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaData DynamicSchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.DynamicSchemaProperties DynamicSchemaProperties(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType? configurationType = default(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationType?), Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel? configurationModel = default(Azure.ResourceManager.WorkloadOrchestration.Models.ConfigurationModel?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.DynamicSchemaVersionData DynamicSchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.ExecutionData ExecutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionProperties ExecutionProperties(string workflowVersionId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus status = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ExecutionStatus ExecutionStatus(System.DateTimeOffset? updateOn = default(System.DateTimeOffset?), int? status = default(int?), string statusMessage = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus> stageHistory = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.InstanceData InstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.InstanceHistoryData InstanceHistoryData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties InstanceHistoryProperties(Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot solutionVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot target = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? activeState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState?), Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties reconciliationPolicy = null, Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus status = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.InstanceProperties InstanceProperties(string solutionVersionId = null, string targetId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? activeState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState?), Azure.ResourceManager.WorkloadOrchestration.Models.ReconciliationPolicyProperties reconciliationPolicy = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus status = null, long? deploymentTimestampEpoch = default(long?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.JobData JobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobProperties JobProperties(Azure.ResourceManager.WorkloadOrchestration.Models.JobType jobType = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobType), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus status = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus), Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase jobParameter = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> steps = null, string triggeredBy = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?), Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.JobStep JobStep(string name = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus status = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string message = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase statistics = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> steps = null, Azure.ResponseError errorDetails = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.RemoveVersionResult RemoveVersionResult(string status = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.ResolvedConfiguration ResolvedConfiguration(string configuration = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaData SchemaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaProperties SchemaProperties(string currentVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaReferenceData SchemaReferenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties SchemaReferenceProperties(string schemaId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData SchemaVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionProperties SchemaVersionProperties(string value = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SchemaVersionWithUpdateType SchemaVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData schemaVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SiteReferenceData SiteReferenceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SiteReferenceProperties SiteReferenceProperties(string siteId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionData SolutionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency SolutionDependency(string solutionVersionId = null, string solutionInstanceName = null, string solutionTemplateVersionId = null, string targetId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency> dependencies = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionProperties SolutionProperties(string solutionTemplateId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.AvailableSolutionTemplateVersion> availableSolutionTemplateVersions = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent SolutionTemplateContent(string solutionTemplateVersionId = null, string solutionInstanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent> solutionDependencies = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateData SolutionTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateProperties SolutionTemplateProperties(string description = null, System.Collections.Generic.IEnumerable<string> capabilities = null, string latestVersion = null, Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState?), bool? enableExternalValidation = default(bool?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData SolutionTemplateVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties properties = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionProperties SolutionTemplateVersionProperties(string configurations = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType? orchestratorType = default(Azure.ResourceManager.WorkloadOrchestration.Models.OrchestratorType?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType SolutionTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? updateType = default(Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType?), string version = null, Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData solutionTemplateVersion = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.SolutionVersionData SolutionVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties SolutionVersionProperties(string solutionTemplateVersionId = null, int? revision = default(int?), string targetDisplayName = null, string configuration = null, string targetLevelConfiguration = null, System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, string reviewId = null, string externalValidationId = null, Azure.ResourceManager.WorkloadOrchestration.Models.State? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.State?), string solutionInstanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependency> solutionDependencies = null, Azure.ResponseError errorDetails = null, string latestActionTrackingUri = null, Azure.ResourceManager.WorkloadOrchestration.Models.JobType? actionType = default(Azure.ResourceManager.WorkloadOrchestration.Models.JobType?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionSnapshot SolutionVersionSnapshot(Azure.Core.ResourceIdentifier solutionVersionId = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> specification = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.StageStatus StageStatus(int? status = default(int?), string statusMessage = null, string stage = null, string nextstage = null, string errorMessage = null, Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? isActive = default(Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState?), System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> inputs = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> outputs = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.TargetData TargetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties properties = null, string etag = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TargetProperties TargetProperties(string description = null, string displayName = null, Azure.Core.ResourceIdentifier contextId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> targetSpecification = null, System.Collections.Generic.IEnumerable<string> capabilities = null, string hierarchyLevel = null, Azure.ResourceManager.WorkloadOrchestration.Models.DeploymentStatus status = null, string solutionScope = null, Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.ResourceState?), Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TargetSnapshot TargetSnapshot(Azure.Core.ResourceIdentifier targetId = null, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> targetSpecification = null, string solutionScope = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.TargetStatus TargetStatus(string name = null, string status = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.ComponentStatus> componentStatuses = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent UninstallSolutionContent(string solutionTemplateId = null, string solutionInstanceName = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent UpdateExternalValidationStatusContent(string solutionVersionId = null, Azure.ResponseError errorDetails = null, string externalValidationId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus validationStatus = default(Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.WorkflowData WorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowProperties WorkflowProperties(string workflowTemplateId = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.WorkflowVersionData WorkflowVersionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties properties = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, string etag = null) { throw null; }
        public static Azure.ResourceManager.WorkloadOrchestration.Models.WorkflowVersionProperties WorkflowVersionProperties(int? revision = default(int?), string configuration = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.WorkloadOrchestration.Models.StageSpec> stageSpec = null, string reviewId = null, Azure.ResourceManager.WorkloadOrchestration.Models.State? state = default(Azure.ResourceManager.WorkloadOrchestration.Models.State?), System.Collections.Generic.IDictionary<string, System.BinaryData> specification = null, Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState?)) { throw null; }
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
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent> SolutionDependencies { get { throw null; } }
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
    public partial class ConfigTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch>
    {
        public ConfigTemplatePatch() { }
        public string ConfigTemplateUpdateDescription { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ConfigTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public ConfigTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData configTemplateVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.ConfigTemplateVersionData ConfigTemplateVersion { get { throw null; } }
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
    public partial class ContextPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch>
    {
        public ContextPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ContextUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.ContextPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class DeployJobContent : Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>
    {
        internal DeployJobContent() { }
        public string ParameterSolutionVersionId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeployJobStepStatistics : Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DeployJobStepStatistics>
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
    public partial class DiagnosticPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch>
    {
        public DiagnosticPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiagnosticUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties>
    {
        public DiagnosticUpdateProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.DiagnosticUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class InstallSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>
    {
        public InstallSolutionContent(string solutionVersionId) { }
        public string SolutionVersionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstallSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstanceHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.InstanceHistoryProperties>
    {
        internal InstanceHistoryProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ActiveState? ActiveState { get { throw null; } }
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
        internal JobProperties() { }
        public string CorrelationId { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobParameterBase JobParameter { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobType JobType { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> Steps { get { throw null; } }
        public string TriggeredBy { get { throw null; } }
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
        internal JobStep() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public string Message { get { throw null; } }
        public string Name { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobStepStatisticsBase Statistics { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobStatus Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.WorkloadOrchestration.Models.JobStep> Steps { get { throw null; } }
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
    public partial class RemoveRevisionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.RemoveRevisionContent>
    {
        public RemoveRevisionContent(string solutionTemplateId, string solutionVersion) { }
        public string SolutionTemplateId { get { throw null; } }
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
    public partial class SchemaPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch>
    {
        public SchemaPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal SchemaReferenceProperties() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string SchemaId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaReferenceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SchemaUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties>
    {
        public SchemaUpdateProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SchemaUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public SchemaVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData schemaVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.SchemaVersionData SchemaVersion { get { throw null; } }
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
    public partial class SolutionDependencyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent>
    {
        public SolutionDependencyContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent> Dependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public string SolutionTemplateId { get { throw null; } set { } }
        public string SolutionTemplateVersion { get { throw null; } set { } }
        public string SolutionVersionId { get { throw null; } set { } }
        public string TargetId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch>
    {
        public SolutionPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties Properties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class SolutionTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent>
    {
        public SolutionTemplateContent(string solutionTemplateVersionId) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionDependencyContent> SolutionDependencies { get { throw null; } }
        public string SolutionInstanceName { get { throw null; } set { } }
        public string SolutionTemplateVersionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionTemplatePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch>
    {
        public SolutionTemplatePatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplatePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public SolutionTemplateVersionWithUpdateType(Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData solutionTemplateVersion) { }
        public Azure.ResourceManager.WorkloadOrchestration.SolutionTemplateVersionData SolutionTemplateVersion { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.UpdateType? UpdateType { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionTemplateVersionWithUpdateType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties>
    {
        public SolutionUpdateProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionVersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent>
    {
        public SolutionVersionContent(string solutionVersionId) { }
        public string SolutionVersionId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SolutionVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.SolutionVersionProperties>
    {
        public SolutionVersionProperties(System.Collections.Generic.IDictionary<string, System.BinaryData> specification) { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.JobType? ActionType { get { throw null; } }
        public string Configuration { get { throw null; } }
        public Azure.ResponseError ErrorDetails { get { throw null; } }
        public string ExternalValidationId { get { throw null; } }
        public string LatestActionTrackingUri { get { throw null; } }
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
        public Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig TaskOption { get { throw null; } set { } }
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
    public partial class TargetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch>
    {
        public TargetPatch() { }
        public Azure.ResourceManager.WorkloadOrchestration.Models.TargetUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TargetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class TaskConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig>
    {
        public TaskConfig() { }
        public int? Concurrency { get { throw null; } set { } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ErrorAction ErrorAction { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.TaskConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class UninstallSolutionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>
    {
        public UninstallSolutionContent(string solutionTemplateId) { }
        public string SolutionInstanceName { get { throw null; } set { } }
        public string SolutionTemplateId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UninstallSolutionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateExternalValidationStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>
    {
        public UpdateExternalValidationStatusContent(string solutionVersionId, string externalValidationId, Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus validationStatus) { }
        public Azure.ResponseError ErrorDetails { get { throw null; } set { } }
        public string ExternalValidationId { get { throw null; } }
        public string SolutionVersionId { get { throw null; } }
        public Azure.ResourceManager.WorkloadOrchestration.Models.ValidationStatus ValidationStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.UpdateExternalValidationStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VersionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent>
    {
        public VersionContent(string version) { }
        public string Version { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.WorkloadOrchestration.Models.VersionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
}
