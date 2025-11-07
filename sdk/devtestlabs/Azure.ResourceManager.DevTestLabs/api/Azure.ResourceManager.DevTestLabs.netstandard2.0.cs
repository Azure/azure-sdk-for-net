namespace Azure.ResourceManager.DevTestLabs
{
    public partial class DevTestLabArmTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>, System.Collections.IEnumerable
    {
        protected DevTestLabArmTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabArmTemplateData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>
    {
        public DevTestLabArmTemplateData(Azure.Core.AzureLocation location) { }
        public System.BinaryData Contents { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string Icon { get { throw null; } }
        public bool? IsEnabled { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo> ParametersValueFilesInfo { get { throw null; } }
        public string Publisher { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArmTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabArmTemplateResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string artifactSourceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>, System.Collections.IEnumerable
    {
        protected DevTestLabArtifactCollection() { }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabArtifactData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>
    {
        public DevTestLabArtifactData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string FilePath { get { throw null; } }
        public string Icon { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public string Publisher { get { throw null; } }
        public string TargetOSType { get { throw null; } }
        public string Title { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabArtifactResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string artifactSourceName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo> GenerateArmTemplate(Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>> GenerateArmTemplateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactSourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>, System.Collections.IEnumerable
    {
        protected DevTestLabArtifactSourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabArtifactSourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>
    {
        public DevTestLabArtifactSourceData(Azure.Core.AzureLocation location) { }
        public string ArmTemplateFolderPath { get { throw null; } set { } }
        public string BranchRef { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DisplayName { get { throw null; } set { } }
        public string FolderPath { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string SecurityToken { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType? SourceType { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? Status { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        public System.Uri Uri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactSourceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabArtifactSourceResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource> GetDevTestLabArmTemplate(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource>> GetDevTestLabArmTemplateAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateCollection GetDevTestLabArmTemplates() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource> GetDevTestLabArtifact(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource>> GetDevTestLabArtifactAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactCollection GetDevTestLabArtifacts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>, System.Collections.IEnumerable
    {
        protected DevTestLabCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabCostCollection : Azure.ResourceManager.ArmCollection
    {
        protected DevTestLabCostCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabCostData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>
    {
        public DevTestLabCostData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string CurrencyCode { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public double? EstimatedLabCost { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails> LabCostDetails { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost> ResourceCosts { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost TargetCost { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabCostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabCostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabCostResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabCostResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCostData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabCostData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabCostData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCostData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabCostData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabCustomImageCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>, System.Collections.IEnumerable
    {
        protected DevTestLabCustomImageCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabCustomImageData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>
    {
        public DevTestLabCustomImageData(Azure.Core.AzureLocation location) { }
        public string Author { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan CustomImagePlan { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo> DataDiskStorageInfo { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsPlanAuthorized { get { throw null; } set { } }
        public string ManagedImageId { get { throw null; } set { } }
        public string ManagedSnapshotId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd Vhd { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm Vm { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabCustomImageResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabCustomImageResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>
    {
        public DevTestLabData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement Announcement { get { throw null; } set { } }
        public string ArtifactsStorageAccount { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DefaultPremiumStorageAccount { get { throw null; } }
        public string DefaultStorageAccount { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission? EnvironmentPermission { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedProperties { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType? LabStorageType { get { throw null; } set { } }
        public string LoadBalancerId { get { throw null; } }
        public System.Collections.Generic.IList<string> MandatoryArtifactsResourceIdsLinux { get { throw null; } }
        public System.Collections.Generic.IList<string> MandatoryArtifactsResourceIdsWindows { get { throw null; } }
        public string NetworkSecurityGroupId { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk? PremiumDataDisks { get { throw null; } set { } }
        public string PremiumDataDiskStorageAccount { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public string PublicIPId { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport Support { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string VmCreationResourceGroup { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>, System.Collections.IEnumerable
    {
        protected DevTestLabDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabDiskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>
    {
        public DevTestLabDiskData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DiskBlobName { get { throw null; } set { } }
        public int? DiskSizeGiB { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType? DiskType { get { throw null; } set { } }
        public System.Uri DiskUri { get { throw null; } set { } }
        public string HostCaching { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LeasedByLabVmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedDiskId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string StorageAccountId { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabDiskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabDiskResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Attach(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AttachAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Detach(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabEnvironmentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>, System.Collections.IEnumerable
    {
        protected DevTestLabEnvironmentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabEnvironmentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>
    {
        public DevTestLabEnvironmentData(Azure.Core.AzureLocation location) { }
        public string ArmTemplateDisplayName { get { throw null; } set { } }
        public string CreatedByUser { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment DeploymentProperties { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string ResourceGroupId { get { throw null; } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabEnvironmentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabEnvironmentResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabFormulaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>, System.Collections.IEnumerable
    {
        protected DevTestLabFormulaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabFormulaData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>
    {
        public DevTestLabFormulaData(Azure.Core.AzureLocation location) { }
        public string Author { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent FormulaContent { get { throw null; } set { } }
        public string LabVmId { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabFormulaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabFormulaResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabGlobalScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabGlobalScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabGlobalScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabGlobalScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Retarget(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RetargetAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabNotificationChannelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>, System.Collections.IEnumerable
    {
        protected DevTestLabNotificationChannelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabNotificationChannelData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>
    {
        public DevTestLabNotificationChannelData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string EmailRecipient { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent> Events { get { throw null; } }
        public string NotificationLocale { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        public System.Uri WebHookUri { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabNotificationChannelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabNotificationChannelResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Notify(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> NotifyAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>, System.Collections.IEnumerable
    {
        protected DevTestLabPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>
    {
        public DevTestLabPolicyData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType? EvaluatorType { get { throw null; } set { } }
        public string FactData { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName? FactName { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus? Status { get { throw null; } set { } }
        public string Threshold { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabPolicyResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string policySetName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ClaimAnyVm(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimAnyVmAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation CreateEnvironment(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateEnvironmentAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult> EvaluatePolicies(string name, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>> EvaluatePoliciesAsync(string name, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ExportResourceUsage(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExportResourceUsageAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult> GenerateUploadUri(Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>> GenerateUploadUriAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource> GetDevTestLabArtifactSource(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource>> GetDevTestLabArtifactSourceAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceCollection GetDevTestLabArtifactSources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource> GetDevTestLabCost(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCostResource>> GetDevTestLabCostAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCostCollection GetDevTestLabCosts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource> GetDevTestLabCustomImage(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource>> GetDevTestLabCustomImageAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageCollection GetDevTestLabCustomImages() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource> GetDevTestLabFormula(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource>> GetDevTestLabFormulaAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabFormulaCollection GetDevTestLabFormulas() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource> GetDevTestLabNotificationChannel(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource>> GetDevTestLabNotificationChannelAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelCollection GetDevTestLabNotificationChannels() { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabPolicyCollection GetDevTestLabPolicies(string policySetName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource> GetDevTestLabPolicy(string policySetName, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource>> GetDevTestLabPolicyAsync(string policySetName, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetDevTestLabSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> GetDevTestLabScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleCollection GetDevTestLabSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> GetDevTestLabServiceRunner(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> GetDevTestLabServiceRunnerAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerCollection GetDevTestLabServiceRunners() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> GetDevTestLabUser(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> GetDevTestLabUserAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabUserCollection GetDevTestLabUsers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> GetDevTestLabVirtualNetwork(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> GetDevTestLabVirtualNetworkAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkCollection GetDevTestLabVirtualNetworks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> GetDevTestLabVm(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> GetDevTestLabVmAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmCollection GetDevTestLabVms() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage> GetGalleryImages(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage> GetGalleryImagesAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.Models.SubResource> GetVhds(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.Models.SubResource> GetVhdsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ImportVm(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ImportVmAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetApplicable(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetApplicableAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabScheduleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>
    {
        public DevTestLabScheduleData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DailyRecurrenceTime { get { throw null; } set { } }
        public int? HourlyRecurrenceMinute { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings NotificationSettings { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? Status { get { throw null; } set { } }
        public string TargetResourceId { get { throw null; } set { } }
        public string TaskType { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails WeeklyRecurrence { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabSecretCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>, System.Collections.IEnumerable
    {
        protected DevTestLabSecretCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabSecretData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabSecretData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>
    {
        public DevTestLabSecretData(Azure.Core.AzureLocation location) { }
        public string ProvisioningState { get { throw null; } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabSecretData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabSecretData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabSecretResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabSecretResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabSecretData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabSecretData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabSecretData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabSecretData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>, System.Collections.IEnumerable
    {
        protected DevTestLabServiceFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabServiceFabricData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>
    {
        public DevTestLabServiceFabricData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule ApplicableSchedule { get { throw null; } }
        public string EnvironmentId { get { throw null; } set { } }
        public string ExternalServiceFabricId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabServiceFabricResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabServiceFabricResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule> GetApplicableSchedules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>> GetApplicableSchedulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> GetDevTestLabServiceFabricSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> GetDevTestLabServiceFabricScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleCollection GetDevTestLabServiceFabricSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceFabricScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabServiceFabricScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabServiceFabricScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabServiceFabricScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string userName, string serviceFabricName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceRunnerCollection : Azure.ResourceManager.ArmCollection
    {
        protected DevTestLabServiceRunnerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabServiceRunnerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>
    {
        public DevTestLabServiceRunnerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity Identity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabServiceRunnerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabServiceRunnerResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DevTestLabsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLab(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource GetDevTestLabArmTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource GetDevTestLabArtifactResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource GetDevTestLabArtifactSourceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetDevTestLabAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCostResource GetDevTestLabCostResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource GetDevTestLabCustomImageResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource GetDevTestLabDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource GetDevTestLabEnvironmentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource GetDevTestLabFormulaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedule(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetDevTestLabGlobalScheduleAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource GetDevTestLabGlobalScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleCollection GetDevTestLabGlobalSchedules(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedules(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedulesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource GetDevTestLabNotificationChannelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource GetDevTestLabPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabResource GetDevTestLabResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCollection GetDevTestLabs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLabs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLabsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource GetDevTestLabScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource GetDevTestLabSecretResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource GetDevTestLabServiceFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource GetDevTestLabServiceFabricScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource GetDevTestLabServiceRunnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabUserResource GetDevTestLabUserResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource GetDevTestLabVirtualNetworkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVmResource GetDevTestLabVmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource GetDevTestLabVmScheduleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DevTestLabUserCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>, System.Collections.IEnumerable
    {
        protected DevTestLabUserCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabUserData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabUserData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>
    {
        public DevTestLabUserData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity Identity { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore SecretStore { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabUserResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabUserResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabUserData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource> GetDevTestLabDisk(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource>> GetDevTestLabDiskAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabDiskCollection GetDevTestLabDisks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource> GetDevTestLabEnvironment(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource>> GetDevTestLabEnvironmentAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentCollection GetDevTestLabEnvironments() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource> GetDevTestLabSecret(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource>> GetDevTestLabSecretAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabSecretCollection GetDevTestLabSecrets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource> GetDevTestLabServiceFabric(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource>> GetDevTestLabServiceFabricAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricCollection GetDevTestLabServiceFabrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabUserData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabUserData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabUserData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabUserResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabVirtualNetworkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>, System.Collections.IEnumerable
    {
        protected DevTestLabVirtualNetworkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabVirtualNetworkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>
    {
        public DevTestLabVirtualNetworkData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet> AllowedSubnets { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string ExternalProviderResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet> ExternalSubnets { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride> SubnetOverrides { get { throw null; } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabVirtualNetworkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabVirtualNetworkResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabVmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>, System.Collections.IEnumerable
    {
        protected DevTestLabVmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabVmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabVmData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>
    {
        public DevTestLabVmData(Azure.Core.AzureLocation location) { }
        public bool? AllowClaim { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule ApplicableSchedule { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus ArtifactDeploymentStatus { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo> Artifacts { get { throw null; } }
        public Azure.Core.ResourceIdentifier ComputeId { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties ComputeVm { get { throw null; } }
        public string CreatedByUser { get { throw null; } }
        public string CreatedByUserId { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string CustomImageId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties> DataDiskParameters { get { throw null; } }
        public bool? DisallowPublicIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier EnvironmentId { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public string Fqdn { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference GalleryImageReference { get { throw null; } set { } }
        public bool? IsAuthenticationWithSshKey { get { throw null; } set { } }
        public string LabSubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LabVirtualNetworkId { get { throw null; } set { } }
        public string LastKnownPowerState { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface NetworkInterface { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
        public string OSType { get { throw null; } }
        public string OwnerObjectId { get { throw null; } set { } }
        public string OwnerUserPrincipalName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string SharedImageId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter> ScheduleParameters { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public string SshKey { get { throw null; } set { } }
        public string StorageType { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource? VmCreationSource { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabVmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabVmResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.ResourceManager.ArmOperation AddDataDisk(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties dataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AddDataDiskAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties dataDiskProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ApplyArtifacts(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ApplyArtifactsAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Claim(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ClaimAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DetachDataDisk(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DetachDataDiskAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule> GetApplicableSchedules(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>> GetApplicableSchedulesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> GetDevTestLabVmSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> GetDevTestLabVmScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleCollection GetDevTestLabVmSchedules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection> GetRdpFileContents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>> GetRdpFileContentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Redeploy(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RedeployAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Resize(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResizeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Restart(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabVmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabVmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabVmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TransferDisks(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TransferDisksAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation UnClaim(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UnClaimAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DevTestLabVmScheduleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>, System.Collections.IEnumerable
    {
        protected DevTestLabVmScheduleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> Get(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> GetAll(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> GetAllAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> GetAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> GetIfExists(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> GetIfExistsAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevTestLabVmScheduleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevTestLabVmScheduleResource() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string labName, string vmName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Execute(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ExecuteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> Get(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> GetAsync(string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource> Update(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource>> UpdateAsync(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevTestLabs.Mocking
{
    public partial class MockableDevTestLabsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDevTestLabsArmClient() { }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateResource GetDevTestLabArmTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactResource GetDevTestLabArtifactResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceResource GetDevTestLabArtifactSourceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCostResource GetDevTestLabCostResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageResource GetDevTestLabCustomImageResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabDiskResource GetDevTestLabDiskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentResource GetDevTestLabEnvironmentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabFormulaResource GetDevTestLabFormulaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource GetDevTestLabGlobalScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelResource GetDevTestLabNotificationChannelResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabPolicyResource GetDevTestLabPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabResource GetDevTestLabResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabScheduleResource GetDevTestLabScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabSecretResource GetDevTestLabSecretResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricResource GetDevTestLabServiceFabricResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricScheduleResource GetDevTestLabServiceFabricScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerResource GetDevTestLabServiceRunnerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabUserResource GetDevTestLabUserResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkResource GetDevTestLabVirtualNetworkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmResource GetDevTestLabVmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabVmScheduleResource GetDevTestLabVmScheduleResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDevTestLabsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevTestLabsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLab(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabResource>> GetDevTestLabAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedule(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource>> GetDevTestLabGlobalScheduleAsync(string name, string expand = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleCollection GetDevTestLabGlobalSchedules() { throw null; }
        public virtual Azure.ResourceManager.DevTestLabs.DevTestLabCollection GetDevTestLabs() { throw null; }
    }
    public partial class MockableDevTestLabsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevTestLabsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedules(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabGlobalScheduleResource> GetDevTestLabGlobalSchedulesAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLabs(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevTestLabs.DevTestLabResource> GetDevTestLabsAsync(string expand = null, string filter = null, int? top = default(int?), string orderby = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevTestLabs.Models
{
    public static partial class ArmDevTestLabsModelFactory
    {
        public static Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk ComputeDataDisk(string name = null, System.Uri diskUri = null, string managedDiskId = null, int? diskSizeGiB = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus ComputeVmInstanceViewStatus(string code = null, string displayStatus = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties ComputeVmProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus> statuses = null, string osType = null, string vmSize = null, string networkInterfaceId = null, string osDiskId = null, System.Collections.Generic.IEnumerable<string> dataDiskIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk> dataDisks = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement DevTestLabAnnouncement(string title = null, string markdown = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? enabled = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus?), System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), bool? isExpired = default(bool?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule DevTestLabApplicableSchedule(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData labVmsShutdown = null, Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData labVmsStartup = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArmTemplateData DevTestLabArmTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string displayName = null, string description = null, string publisher = null, string icon = null, System.BinaryData contents = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo> parametersValueFilesInfo = null, bool? isEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo DevTestLabArmTemplateInfo(System.BinaryData template = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArtifactData DevTestLabArtifactData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string title = null, string description = null, string publisher = null, string filePath = null, string icon = null, string targetOSType = null, System.BinaryData parameters = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus DevTestLabArtifactDeploymentStatus(string deploymentStatus = null, int? artifactsApplied = default(int?), int? totalArtifacts = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabArtifactSourceData DevTestLabArtifactSourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string displayName = null, System.Uri uri = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType? sourceType = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType?), string folderPath = null, string armTemplateFolderPath = null, string branchRef = null, string securityToken = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? status = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCostData DevTestLabCostData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost targetCost = null, double? estimatedLabCost = default(double?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails> labCostDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost> resourceCosts = null, string currencyCode = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails DevTestLabCostDetails(System.DateTimeOffset? on = default(System.DateTimeOffset?), double? cost = default(double?), Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType? costType = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabCustomImageData DevTestLabCustomImageData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm vm = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd vhd = null, string description = null, string author = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string managedImageId = null, string managedSnapshotId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo> dataDiskStorageInfo = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan customImagePlan = null, bool? isPlanAuthorized = default(bool?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabData DevTestLabData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string defaultStorageAccount = null, string defaultPremiumStorageAccount = null, string artifactsStorageAccount = null, string premiumDataDiskStorageAccount = null, string vaultName = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType? labStorageType = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType?), System.Collections.Generic.IEnumerable<string> mandatoryArtifactsResourceIdsLinux = null, System.Collections.Generic.IEnumerable<string> mandatoryArtifactsResourceIdsWindows = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk? premiumDataDisks = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk?), Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission? environmentPermission = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission?), Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement announcement = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport support = null, string vmCreationResourceGroup = null, string publicIPId = null, string loadBalancerId = null, string networkSecurityGroupId = null, System.Collections.Generic.IDictionary<string, string> extendedProperties = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabDiskData DevTestLabDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType? diskType = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType?), int? diskSizeGiB = default(int?), Azure.Core.ResourceIdentifier leasedByLabVmId = null, string diskBlobName = null, System.Uri diskUri = null, string storageAccountId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string hostCaching = null, Azure.Core.ResourceIdentifier managedDiskId = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabEnvironmentData DevTestLabEnvironmentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment deploymentProperties = null, string armTemplateDisplayName = null, string resourceGroupId = null, string createdByUser = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult DevTestLabEvaluatePoliciesResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult> results = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet DevTestLabExternalSubnet(Azure.Core.ResourceIdentifier id = null, string name = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabFormulaData DevTestLabFormulaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, string author = null, string osType = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent formulaContent = null, string labVmId = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage DevTestLabGalleryImage(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string author = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string description = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference imageReference = null, string icon = null, bool? isEnabled = default(bool?), string planId = null, bool? isPlanAuthorized = default(bool?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult DevTestLabGenerateUploadUriResult(System.Uri uploadUri = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabNotificationChannelData DevTestLabNotificationChannelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Uri webHookUri = null, string emailRecipient = null, string notificationLocale = null, string description = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent> events = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo DevTestLabParametersValueFileInfo(string fileName = null, System.BinaryData parametersValueInfo = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabPolicyData DevTestLabPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string description = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus? status = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus?), Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName? factName = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName?), string factData = null, string threshold = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType? evaluatorType = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult DevTestLabPolicySetResult(bool? hasError = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation> policyViolations = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation DevTestLabPolicyViolation(string code = null, string message = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection DevTestLabRdpConnection(string contents = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost DevTestLabResourceCost(string resourceName = null, string resourceUniqueId = null, double? resourceCost = default(double?), string resourceType = null, string resourceOwner = null, string resourcePricingTier = null, string resourceStatus = null, string resourceId = null, string externalResourceId = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter DevTestLabScheduleCreationParameter(string name = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? status = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus?), string taskType = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails weeklyRecurrence = null, string dailyRecurrenceTime = null, int? hourlyRecurrenceMinute = default(int?), string timeZoneId = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings notificationSettings = null, Azure.Core.ResourceIdentifier targetResourceId = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData DevTestLabScheduleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? status = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus?), string taskType = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails weeklyRecurrence = null, string dailyRecurrenceTime = null, int? hourlyRecurrenceMinute = default(int?), string timeZoneId = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings notificationSettings = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string targetResourceId = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabSecretData DevTestLabSecretData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string value = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceFabricData DevTestLabServiceFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string externalServiceFabricId = null, string environmentId = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule applicableSchedule = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabServiceRunnerData DevTestLabServiceRunnerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabUserData DevTestLabUserData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity identity = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore secretStore = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVirtualNetworkData DevTestLabVirtualNetworkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet> allowedSubnets = null, string description = null, string externalProviderResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet> externalSubnets = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride> subnetOverrides = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.DevTestLabVmData DevTestLabVmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string notes = null, string ownerObjectId = null, string ownerUserPrincipalName = null, string createdByUserId = null, string createdByUser = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier computeId = null, string customImageId = null, string osType = null, string size = null, string userName = null, string password = null, string sshKey = null, bool? isAuthenticationWithSshKey = default(bool?), string fqdn = null, string labSubnetName = null, Azure.Core.ResourceIdentifier labVirtualNetworkId = null, bool? disallowPublicIPAddress = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo> artifacts = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus artifactDeploymentStatus = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference galleryImageReference = null, string planId = null, Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties computeVm = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface networkInterface = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule applicableSchedule = null, System.DateTimeOffset? expireOn = default(System.DateTimeOffset?), bool? allowClaim = default(bool?), string storageType = null, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource? vmCreationSource = default(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource?), Azure.Core.ResourceIdentifier environmentId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties> dataDiskParameters = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter> scheduleParameters = null, string lastKnownPowerState = null, string provisioningState = null, System.Guid? uniqueIdentifier = default(System.Guid?), string SharedImageId = null) { throw null; }
    }
    public partial class AttachNewDataDiskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails>
    {
        public AttachNewDataDiskDetails() { }
        public string DiskName { get { throw null; } set { } }
        public int? DiskSizeGiB { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType? DiskType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeDataDisk : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk>
    {
        internal ComputeDataDisk() { }
        public int? DiskSizeGiB { get { throw null; } }
        public System.Uri DiskUri { get { throw null; } }
        public string ManagedDiskId { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeVmInstanceViewStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus>
    {
        internal ComputeVmInstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeVmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties>
    {
        internal ComputeVmProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> DataDiskIds { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ComputeDataDisk> DataDisks { get { throw null; } }
        public string NetworkInterfaceId { get { throw null; } }
        public string OSDiskId { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.ComputeVmInstanceViewStatus> Statuses { get { throw null; } }
        public string VmSize { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.ComputeVmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabAnnouncement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement>
    {
        public DevTestLabAnnouncement() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool? IsExpired { get { throw null; } set { } }
        public string Markdown { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string Title { get { throw null; } set { } }
        public System.Guid? UniqueIdentifier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabAnnouncement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabApplicableSchedule : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>
    {
        public DevTestLabApplicableSchedule(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData LabVmsShutdown { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.DevTestLabScheduleData LabVmsStartup { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabApplicableSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArmTemplateInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>
    {
        internal DevTestLabArmTemplateInfo() { }
        public System.BinaryData Parameters { get { throw null; } }
        public System.BinaryData Template { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArmTemplateParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter>
    {
        public DevTestLabArmTemplateParameter() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactDeploymentStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus>
    {
        internal DevTestLabArtifactDeploymentStatus() { }
        public int? ArtifactsApplied { get { throw null; } }
        public string DeploymentStatus { get { throw null; } }
        public int? TotalArtifacts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactDeploymentStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactGenerateArmTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent>
    {
        public DevTestLabArtifactGenerateArmTemplateContent() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption? FileUploadOptions { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter> Parameters { get { throw null; } }
        public string VmName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactGenerateArmTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactInstallInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo>
    {
        public DevTestLabArtifactInstallInfo() { }
        public string ArtifactId { get { throw null; } set { } }
        public string ArtifactTitle { get { throw null; } set { } }
        public string DeploymentStatusMessage { get { throw null; } set { } }
        public System.DateTimeOffset? InstallOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter> Parameters { get { throw null; } }
        public string Status { get { throw null; } set { } }
        public string VmExtensionStatusMessage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter>
    {
        public DevTestLabArtifactParameter() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabArtifactSourcePatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch>
    {
        public DevTestLabArtifactSourcePatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactSourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabCostDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails>
    {
        internal DevTestLabCostDetails() { }
        public double? Cost { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType? CostType { get { throw null; } }
        public System.DateTimeOffset? On { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabCostThreshold : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold>
    {
        public DevTestLabCostThreshold() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus? DisplayOnChart { get { throw null; } set { } }
        public string NotificationSent { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus? SendNotificationWhenExceeded { get { throw null; } set { } }
        public string ThresholdId { get { throw null; } set { } }
        public double? ThresholdValue { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabCostThresholdStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabCostThresholdStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThresholdStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabCostType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabCostType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType Projected { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType Reported { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabCustomImageOSType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabCustomImageOSType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType Linux { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType None { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabCustomImagePatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch>
    {
        public DevTestLabCustomImagePatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabCustomImagePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan>
    {
        public DevTestLabCustomImagePlan() { }
        public string Id { get { throw null; } set { } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImagePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabCustomImageVhd : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd>
    {
        public DevTestLabCustomImageVhd(Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType osType) { }
        public string ImageName { get { throw null; } set { } }
        public bool? IsSysPrepEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageOSType OSType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVhd>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabCustomImageVm : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm>
    {
        public DevTestLabCustomImageVm() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState? LinuxOSState { get { throw null; } set { } }
        public string SourceVmId { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.WindowsOSState? WindowsOSState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCustomImageVm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabDataDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties>
    {
        public DevTestLabDataDiskProperties() { }
        public Azure.ResourceManager.DevTestLabs.Models.AttachNewDataDiskDetails AttachNewDataDiskOptions { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ExistingLabDiskId { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption? HostCaching { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabDataDiskStorageTypeInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo>
    {
        public DevTestLabDataDiskStorageTypeInfo() { }
        public string Lun { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType? StorageType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskStorageTypeInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabDiskAttachContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent>
    {
        public DevTestLabDiskAttachContent() { }
        public Azure.Core.ResourceIdentifier LeasedByLabVmId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskAttachContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabDiskDetachContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent>
    {
        public DevTestLabDiskDetachContent() { }
        public Azure.Core.ResourceIdentifier LeasedByLabVmId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskDetachContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabDiskPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch>
    {
        public DevTestLabDiskPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDiskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabEnableStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabEnableStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabEnvironmentDeployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment>
    {
        public DevTestLabEnvironmentDeployment() { }
        public Azure.Core.ResourceIdentifier ArmTemplateId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArmTemplateParameter> Parameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentDeployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabEnvironmentPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch>
    {
        public DevTestLabEnvironmentPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabEnvironmentPermission : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabEnvironmentPermission(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission Contributor { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission Reader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnvironmentPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabEvaluatePoliciesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent>
    {
        public DevTestLabEvaluatePoliciesContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy> Policies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabEvaluatePoliciesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>
    {
        internal DevTestLabEvaluatePoliciesResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePoliciesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabEvaluatePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy>
    {
        public DevTestLabEvaluatePolicy() { }
        public string FactData { get { throw null; } set { } }
        public string FactName { get { throw null; } set { } }
        public string UserObjectId { get { throw null; } set { } }
        public string ValueOffset { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabEvaluatePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabExportResourceUsageContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent>
    {
        public DevTestLabExportResourceUsageContent() { }
        public System.Uri BlobStorageAbsoluteSasUri { get { throw null; } set { } }
        public System.DateTimeOffset? UsageStartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExportResourceUsageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabExternalSubnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet>
    {
        internal DevTestLabExternalSubnet() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabExternalSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabFileUploadOption : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabFileUploadOption(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption None { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption UploadFilesAndGenerateSasTokens { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabFileUploadOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabFormulaPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch>
    {
        public DevTestLabFormulaPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabFormulaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabGalleryImage : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage>
    {
        public DevTestLabGalleryImage(Azure.Core.AzureLocation location) { }
        public string Author { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Icon { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference ImageReference { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public bool? IsPlanAuthorized { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabGalleryImageReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference>
    {
        public DevTestLabGalleryImageReference() { }
        public string Offer { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabGenerateUploadUriContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent>
    {
        public DevTestLabGenerateUploadUriContent() { }
        public string BlobName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabGenerateUploadUriResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>
    {
        internal DevTestLabGenerateUploadUriResult() { }
        public System.Uri UploadUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGenerateUploadUriResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabGlobalScheduleRetargetContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent>
    {
        public DevTestLabGlobalScheduleRetargetContent() { }
        public Azure.Core.ResourceIdentifier CurrentResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabGlobalScheduleRetargetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabHostCachingOption : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabHostCachingOption(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption None { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabHostCachingOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabImportVmContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent>
    {
        public DevTestLabImportVmContent() { }
        public string DestinationVmName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVmResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabImportVmContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabInboundNatRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule>
    {
        public DevTestLabInboundNatRule() { }
        public int? BackendPort { get { throw null; } set { } }
        public int? FrontendPort { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol? TransportProtocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabLinuxOSState : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabLinuxOSState(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState DeprovisionApplied { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState DeprovisionRequested { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState NonDeprovisioned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabLinuxOSState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabManagedIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity>
    {
        public DevTestLabManagedIdentity() { }
        public System.Uri ClientSecretUri { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentityType ManagedIdentityType { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabManagedIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabNetworkInterface : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface>
    {
        public DevTestLabNetworkInterface() { }
        public string DnsName { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        public string PublicIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PublicIPAddressId { get { throw null; } set { } }
        public string RdpAuthority { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabInboundNatRule> SharedPublicIPAddressInboundNatRules { get { throw null; } }
        public string SshAuthority { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabNotificationChannelEvent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent>
    {
        public DevTestLabNotificationChannelEvent() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType? EventName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabNotificationChannelEventType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabNotificationChannelEventType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType AutoShutdown { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType Cost { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabNotificationChannelNotifyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent>
    {
        public DevTestLabNotificationChannelNotifyContent() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelEventType? EventName { get { throw null; } set { } }
        public string JsonPayload { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelNotifyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabNotificationChannelPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch>
    {
        public DevTestLabNotificationChannelPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationChannelPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabNotificationSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings>
    {
        public DevTestLabNotificationSettings() { }
        public string EmailRecipient { get { throw null; } set { } }
        public string NotificationLocale { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? Status { get { throw null; } set { } }
        public int? TimeInMinutes { get { throw null; } set { } }
        public System.Uri WebhookUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter>
    {
        public DevTestLabParameter() { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabParametersValueFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo>
    {
        internal DevTestLabParametersValueFileInfo() { }
        public string FileName { get { throw null; } }
        public System.BinaryData ParametersValueInfo { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabParametersValueFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch>
    {
        public DevTestLabPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabPolicyEvaluatorType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabPolicyEvaluatorType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType AllowedValuesPolicy { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType MaxValuePolicy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyEvaluatorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabPolicyFactName : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabPolicyFactName(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName EnvironmentTemplate { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName GalleryImage { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName LabPremiumVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName LabTargetCost { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName LabVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName LabVmSize { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName ScheduleEditPermission { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName UserOwnedLabPremiumVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName UserOwnedLabVmCount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName UserOwnedLabVmCountInSubnet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyFactName right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabPolicyPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch>
    {
        public DevTestLabPolicyPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabPolicySetResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult>
    {
        internal DevTestLabPolicySetResult() { }
        public bool? HasError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation> PolicyViolations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicySetResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabPolicyStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabPolicyStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabPolicyViolation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation>
    {
        internal DevTestLabPolicyViolation() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPolicyViolation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabPort : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort>
    {
        public DevTestLabPort() { }
        public int? BackendPort { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol? TransportProtocol { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabPremiumDataDisk : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabPremiumDataDisk(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabPremiumDataDisk right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabRdpConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>
    {
        internal DevTestLabRdpConnection() { }
        public string Contents { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabRdpConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabReportingCycleType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabReportingCycleType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType CalendarMonth { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType Custom { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabResourceCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost>
    {
        internal DevTestLabResourceCost() { }
        public string ExternalResourceId { get { throw null; } }
        public double? ResourceCost { get { throw null; } }
        public string ResourceId { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public string ResourceOwner { get { throw null; } }
        public string ResourcePricingTier { get { throw null; } }
        public string ResourceStatus { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public string ResourceUniqueId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourceCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch>
    {
        public DevTestLabResourcePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabScheduleCreationParameter : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter>
    {
        public DevTestLabScheduleCreationParameter() { }
        public string DailyRecurrenceTime { get { throw null; } set { } }
        public int? HourlyRecurrenceMinute { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabNotificationSettings NotificationSettings { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        public string TaskType { get { throw null; } set { } }
        public string TimeZoneId { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails WeeklyRecurrence { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabSchedulePatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch>
    {
        public DevTestLabSchedulePatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSchedulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabSecretPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch>
    {
        public DevTestLabSecretPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSecretPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabServiceFabricPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch>
    {
        public DevTestLabServiceFabricPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabServiceFabricPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabSourceControlType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabSourceControlType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType GitHub { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType StorageAccount { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType VsoGit { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabSourceControlType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabStorageType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabStorageType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType Premium { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType Standard { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType StandardSsd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabSubnet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet>
    {
        public DevTestLabSubnet() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType? AllowPublicIP { get { throw null; } set { } }
        public string LabSubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabSubnetOverride : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride>
    {
        public DevTestLabSubnetOverride() { }
        public string LabSubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabPort> SharedPublicIPAddressAllowedPorts { get { throw null; } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType? UseInVmCreationPermission { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType? UsePublicIPAddressPermission { get { throw null; } set { } }
        public string VirtualNetworkPoolName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSubnetOverride>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabSupport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport>
    {
        public DevTestLabSupport() { }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabEnableStatus? Enabled { get { throw null; } set { } }
        public string Markdown { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabSupport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabTargetCost : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost>
    {
        public DevTestLabTargetCost() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabCostThreshold> CostThresholds { get { throw null; } }
        public System.DateTimeOffset? CycleEndOn { get { throw null; } set { } }
        public System.DateTimeOffset? CycleStartOn { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabReportingCycleType? CycleType { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus? Status { get { throw null; } set { } }
        public int? Target { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCost>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabTargetCostStatus : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabTargetCostStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabTargetCostStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabTransportProtocol : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabTransportProtocol(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol Tcp { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol Udp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabUsagePermissionType : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabUsagePermissionType(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType Allow { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType Default { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabUsagePermissionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabUserIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity>
    {
        public DevTestLabUserIdentity() { }
        public string AppId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } set { } }
        public string PrincipalName { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabUserPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch>
    {
        public DevTestLabUserPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabUserSecretStore : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore>
    {
        public DevTestLabUserSecretStore() { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabUserSecretStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabVirtualNetworkPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch>
    {
        public DevTestLabVirtualNetworkPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVirtualNetworkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabVmApplyArtifactsContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent>
    {
        public DevTestLabVmApplyArtifactsContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo> Artifacts { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmApplyArtifactsContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabVmCreationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent>
    {
        public DevTestLabVmCreationContent() { }
        public bool? AllowClaim { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabArtifactInstallInfo> Artifacts { get { throw null; } }
        public int? BulkCreationParametersInstanceCount { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string CustomImageId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabDataDiskProperties> DataDiskParameters { get { throw null; } }
        public bool? DisallowPublicIPAddress { get { throw null; } set { } }
        public string EnvironmentId { get { throw null; } set { } }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabGalleryImageReference GalleryImageReference { get { throw null; } set { } }
        public bool? IsAuthenticationWithSshKey { get { throw null; } set { } }
        public string LabSubnetName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LabVirtualNetworkId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.DevTestLabs.Models.DevTestLabNetworkInterface NetworkInterface { get { throw null; } set { } }
        public string Notes { get { throw null; } set { } }
        public string OwnerObjectId { get { throw null; } set { } }
        public string OwnerUserPrincipalName { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string SharedImageId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevTestLabs.Models.DevTestLabScheduleCreationParameter> ScheduleParameters { get { throw null; } }
        public string Size { get { throw null; } set { } }
        public string SshKey { get { throw null; } set { } }
        public string StorageType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string UserName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevTestLabVmCreationSource : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevTestLabVmCreationSource(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource FromCustomImage { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource FromGalleryImage { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource FromSharedGalleryImage { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource left, Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmCreationSource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevTestLabVmDetachDataDiskContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent>
    {
        public DevTestLabVmDetachDataDiskContent() { }
        public Azure.Core.ResourceIdentifier ExistingLabDiskId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmDetachDataDiskContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabVmPatch : Azure.ResourceManager.DevTestLabs.Models.DevTestLabResourcePatch, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch>
    {
        public DevTestLabVmPatch() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabVmResizeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent>
    {
        public DevTestLabVmResizeContent() { }
        public string Size { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabVmResizeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevTestLabWeekDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails>
    {
        public DevTestLabWeekDetails() { }
        public string Time { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Weekdays { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevTestLabs.Models.DevTestLabWeekDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowsOSState : System.IEquatable<Azure.ResourceManager.DevTestLabs.Models.WindowsOSState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowsOSState(string value) { throw null; }
        public static Azure.ResourceManager.DevTestLabs.Models.WindowsOSState NonSysprepped { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.WindowsOSState SysprepApplied { get { throw null; } }
        public static Azure.ResourceManager.DevTestLabs.Models.WindowsOSState SysprepRequested { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevTestLabs.Models.WindowsOSState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevTestLabs.Models.WindowsOSState left, Azure.ResourceManager.DevTestLabs.Models.WindowsOSState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevTestLabs.Models.WindowsOSState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevTestLabs.Models.WindowsOSState left, Azure.ResourceManager.DevTestLabs.Models.WindowsOSState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
