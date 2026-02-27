namespace Azure.ResourceManager.Resources.DeploymentStacks
{
    public partial class AzureResourceManagerResourcesDeploymentStacksContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerResourcesDeploymentStacksContext() { }
        public static Azure.ResourceManager.Resources.DeploymentStacks.AzureResourceManagerResourcesDeploymentStacksContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeploymentStackCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>, System.Collections.IEnumerable
    {
        protected DeploymentStackCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentStackName, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> Get(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetIfExists(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetIfExistsAsync(string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentStackData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>
    {
        public DeploymentStackData() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public bool? BypassStackOutOfSyncError { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference> DeletedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings DenySettings { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension> DeploymentExtensions { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference> DetachedResources { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig> ExtensionConfigs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition> ExternalInputDefinitions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput> ExternalInputs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended> FailedResources { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.BinaryData Outputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink ParametersLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference> Resources { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel? ValidationLevel { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentStackResource() { }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentStackName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction? unmanageActionResourcesWithoutDeleteSupport = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction? unmanageActionResourcesWithoutDeleteSupport = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult> ExportTemplate(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>> ExportTemplateAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult> ValidateStack(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>> ValidateStackAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeploymentStackWhatIfResultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>, System.Collections.IEnumerable
    {
        protected DeploymentStackWhatIfResultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string deploymentStacksWhatIfResultName, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string deploymentStacksWhatIfResultName, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> Get(string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> GetAsync(string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> GetIfExists(string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> GetIfExistsAsync(string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeploymentStackWhatIfResultData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>
    {
        public DeploymentStackWhatIfResultData() { }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackWhatIfResultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeploymentStackWhatIfResultResource() { }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string scope, string deploymentStacksWhatIfResultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction? unmanageActionResourcesWithoutDeleteSupport = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode? unmanageActionResources = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? unmanageActionResourceGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? unmanageActionManagementGroups = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction? unmanageActionResourcesWithoutDeleteSupport = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction?), bool? bypassStackOutOfSyncError = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> WhatIf(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> WhatIfAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class ResourcesDeploymentStacksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource GetDeploymentStackResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> GetDeploymentStackWhatIfResult(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> GetDeploymentStackWhatIfResultAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource GetDeploymentStackWhatIfResultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultCollection GetDeploymentStackWhatIfResults(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.DeploymentStacks.Mocking
{
    public partial class MockableResourcesDeploymentStacksArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableResourcesDeploymentStacksArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource> GetDeploymentStack(Azure.Core.ResourceIdentifier scope, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource>> GetDeploymentStackAsync(Azure.Core.ResourceIdentifier scope, string deploymentStackName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackResource GetDeploymentStackResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackCollection GetDeploymentStacks(Azure.Core.ResourceIdentifier scope) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource> GetDeploymentStackWhatIfResult(Azure.Core.ResourceIdentifier scope, string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource>> GetDeploymentStackWhatIfResultAsync(Azure.Core.ResourceIdentifier scope, string deploymentStacksWhatIfResultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultResource GetDeploymentStackWhatIfResultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultCollection GetDeploymentStackWhatIfResults(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.Resources.DeploymentStacks.Models
{
    public partial class ActionOnUnmanage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>
    {
        public ActionOnUnmanage(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode resources) { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? ManagementGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? ResourceGroups { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode Resources { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction? ResourcesWithoutDeleteSupport { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmResourcesDeploymentStacksModelFactory
    {
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig DeploymentExtensionConfig(System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo DeploymentStackAdditionalErrorInfo(string type = null, System.BinaryData info = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackData DeploymentStackData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResponseError error = null, System.BinaryData template = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink templateLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem> parameters = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig> extensionConfigs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage actionOnUnmanage = null, string deploymentScope = null, string description = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings denySettings = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState?), string correlationId = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel?), bool? bypassStackOutOfSyncError = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference> detachedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference> deletedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended> failedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference> resources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension> deploymentExtensions = null, string deploymentId = null, System.BinaryData outputs = null, System.TimeSpan? duration = default(System.TimeSpan?), string debugSettingDetailLevel = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings DeploymentStackDenySettings(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode mode = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode), System.Collections.Generic.IEnumerable<string> excludedPrincipals = null, System.Collections.Generic.IEnumerable<string> excludedActions = null, bool? applyToChildScopes = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference DeploymentStackManagedResourceReference(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension extension = null, Azure.Core.ResourceType? type = default(Azure.Core.ResourceType?), System.BinaryData identifiers = null, string apiVersion = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode? status = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode? denyStatus = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode?)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference DeploymentStackResourceReference(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension extension = null, Azure.Core.ResourceType? type = default(Azure.Core.ResourceType?), System.BinaryData identifiers = null, string apiVersion = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended DeploymentStackResourceReferenceExtended(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension extension = null, Azure.Core.ResourceType? type = default(Azure.Core.ResourceType?), System.BinaryData identifiers = null, string apiVersion = null, Azure.ResponseError error = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase DeploymentStacksChangeBase(string before = null, string after = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode DeploymentStacksChangeBaseDenyStatusMode(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode? before = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode?), Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode? after = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode?)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus DeploymentStacksChangeBaseDeploymentStacksManagementStatus(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus? before = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus?), Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus? after = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus?)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta DeploymentStacksChangeDelta(System.BinaryData before = null, System.BinaryData after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange> delta = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings DeploymentStacksChangeDeltaDenySettings(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings before = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings after = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange> delta = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic DeploymentStacksDiagnostic(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel level = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel), string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo> additionalInfo = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange DeploymentStacksWhatIfChange(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange> resourceChanges = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings denySettingsChange = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase deploymentScopeChange = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange DeploymentStacksWhatIfPropertyChange(System.BinaryData before = null, System.BinaryData after = null, string path = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType changeType = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange> children = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange DeploymentStacksWhatIfResourceChange(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension extension = null, Azure.Core.ResourceType? type = default(Azure.Core.ResourceType?), System.BinaryData identifiers = null, string apiVersion = null, string deploymentId = null, string symbolicName = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType changeType = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType), Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty changeCertainty = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty), Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus managementStatusChange = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode denyStatusChange = null, string unsupportedReason = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta resourceConfigurationChanges = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult DeploymentStackTemplateExportResult(System.BinaryData template = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink templateLink = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties DeploymentStackValidateProperties(Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage actionOnUnmanage = null, string correlationId = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings denySettings = null, string deploymentScope = null, string description = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem> parameters = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink templateLink = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference> validatedResources = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension> deploymentExtensions = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel?)) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult DeploymentStackValidateResult(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), string name = null, Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResponseError error = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.DeploymentStackWhatIfResultData DeploymentStackWhatIfResultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties properties = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties DeploymentStackWhatIfResultProperties(Azure.ResponseError error = null, System.BinaryData template = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink templateLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem> parameters = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink parametersLink = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig> extensionConfigs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput> externalInputs = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition> externalInputDefinitions = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage actionOnUnmanage = null, string debugSettingDetailLevel = null, string deploymentScope = null, string description = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings denySettings = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState? provisioningState = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState?), string correlationId = null, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel? validationLevel = default(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel?), Azure.Core.ResourceIdentifier deploymentStackResourceId = null, System.DateTimeOffset? deploymentStackLastModifiedOn = default(System.DateTimeOffset?), System.TimeSpan retentionInterval = default(System.TimeSpan), Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange changes = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic> diagnostics = null) { throw null; }
    }
    public partial class DeploymentExtension : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension>
    {
        public DeploymentExtension(string name, string version) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ConfigAdditionalProperties { get { throw null; } }
        public string ConfigId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExtensionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig>
    {
        public DeploymentExtensionConfig() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExternalInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput>
    {
        public DeploymentExternalInput(System.BinaryData value) { }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentExternalInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition>
    {
        public DeploymentExternalInputDefinition(string kind) { }
        public System.BinaryData Config { get { throw null; } set { } }
        public string Kind { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentParameterItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem>
    {
        public DeploymentParameterItem() { }
        public string Expression { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference Reference { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackAdditionalErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo>
    {
        public DeploymentStackAdditionalErrorInfo() { }
        public System.BinaryData Info { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackDenySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings>
    {
        public DeploymentStackDenySettings(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode mode) { }
        public bool? ApplyToChildScopes { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ExcludedActions { get { throw null; } }
        public System.Collections.Generic.IList<string> ExcludedPrincipals { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode Mode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStackDenySettingsMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStackDenySettingsMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettingsMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStackDenyStatusMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStackDenyStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode DenyDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode DenyWriteAndDelete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode Inapplicable { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode None { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode NotSupported { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode RemovedBySystem { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStackManagedResourceReference : Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference>
    {
        public DeploymentStackManagedResourceReference() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode? DenyStatus { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode? Status { get { throw null; } set { } }
        protected override Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackManagedResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStackProvisioningState : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStackProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Canceling { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState DeletingResources { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Deploying { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Initializing { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState UpdatingDenyAssignments { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Validating { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState Waiting { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStackResourceReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference>
    {
        public DeploymentStackResourceReference() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension Extension { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public Azure.Core.ResourceType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackResourceReferenceExtended : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended>
    {
        public DeploymentStackResourceReferenceExtended() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension Extension { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public Azure.Core.ResourceType? Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReferenceExtended>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksChangeBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase>
    {
        internal DeploymentStacksChangeBase() { }
        public string After { get { throw null; } }
        public string Before { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksChangeBaseDenyStatusMode : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode>
    {
        internal DeploymentStacksChangeBaseDenyStatusMode() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode? After { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenyStatusMode? Before { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksChangeBaseDeploymentStacksManagementStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus>
    {
        internal DeploymentStacksChangeBaseDeploymentStacksManagementStatus() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus? After { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus? Before { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksChangeDelta : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta>
    {
        internal DeploymentStacksChangeDelta() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange> Delta { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksChangeDeltaDenySettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings>
    {
        internal DeploymentStacksChangeDeltaDenySettings() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings After { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings Before { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange> Delta { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksDiagnostic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic>
    {
        internal DeploymentStacksDiagnostic() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackAdditionalErrorInfo> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel Level { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksDiagnosticLevel : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksDiagnosticLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel Error { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel Info { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnosticLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksManagementStatus : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksManagementStatus(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus Managed { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus Unknown { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus Unmanaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksManagementStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStacksParametersLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>
    {
        public DeploymentStacksParametersLink(System.Uri uri) { }
        public string ContentVersion { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksTemplateLink : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>
    {
        public DeploymentStacksTemplateLink() { }
        public string ContentVersion { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string QueryString { get { throw null; } set { } }
        public string RelativePath { get { throw null; } set { } }
        public System.Uri Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStacksWhatIfChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange>
    {
        internal DeploymentStacksWhatIfChange() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDeltaDenySettings DenySettingsChange { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBase DeploymentScopeChange { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange> ResourceChanges { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksWhatIfChangeCertainty : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksWhatIfChangeCertainty(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty Definite { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty Potential { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksWhatIfChangeType : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksWhatIfChangeType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType Create { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType Detach { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType Modify { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType NoChange { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType Unsupported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStacksWhatIfPropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange>
    {
        internal DeploymentStacksWhatIfPropertyChange() { }
        public System.BinaryData After { get { throw null; } }
        public System.BinaryData Before { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType ChangeType { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange> Children { get { throw null; } }
        public string Path { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStacksWhatIfPropertyChangeType : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStacksWhatIfPropertyChangeType(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType Array { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType Create { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType Modify { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType NoEffect { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfPropertyChangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStacksWhatIfResourceChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange>
    {
        internal DeploymentStacksWhatIfResourceChange() { }
        public string ApiVersion { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeCertainty ChangeCertainty { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChangeType ChangeType { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDenyStatusMode DenyStatusChange { get { throw null; } }
        public string DeploymentId { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension Extension { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public System.BinaryData Identifiers { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeBaseDeploymentStacksManagementStatus ManagementStatusChange { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksChangeDelta ResourceConfigurationChanges { get { throw null; } }
        public string SymbolicName { get { throw null; } }
        public Azure.Core.ResourceType? Type { get { throw null; } }
        public string UnsupportedReason { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfResourceChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackTemplateExportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>
    {
        internal DeploymentStackTemplateExportResult() { }
        public System.BinaryData Template { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackTemplateExportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>
    {
        public DeploymentStackValidateProperties() { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings DenySettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtension> DeploymentExtensions { get { throw null; } }
        public string DeploymentScope { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackResourceReference> ValidatedResources { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel? ValidationLevel { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentStackValidateResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>
    {
        internal DeploymentStackValidateResult() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeploymentStackValidationLevel : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeploymentStackValidationLevel(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel Provider { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel ProviderNoRbac { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel Template { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel left, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentStackWhatIfResultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties>
    {
        public DeploymentStackWhatIfResultProperties(Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage actionOnUnmanage, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings denySettings, Azure.Core.ResourceIdentifier deploymentStackResourceId, System.TimeSpan retentionInterval) { }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.ActionOnUnmanage ActionOnUnmanage { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksWhatIfChange Changes { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string DebugSettingDetailLevel { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackDenySettings DenySettings { get { throw null; } set { } }
        public string DeploymentScope { get { throw null; } set { } }
        public System.DateTimeOffset? DeploymentStackLastModifiedOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier DeploymentStackResourceId { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksDiagnostic> Diagnostics { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExtensionConfig> ExtensionConfigs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInputDefinition> ExternalInputDefinitions { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentExternalInput> ExternalInputs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentParameterItem> Parameters { get { throw null; } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksParametersLink ParametersLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackProvisioningState? ProvisioningState { get { throw null; } }
        public System.TimeSpan RetentionInterval { get { throw null; } set { } }
        public System.BinaryData Template { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStacksTemplateLink TemplateLink { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackValidationLevel? ValidationLevel { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.DeploymentStackWhatIfResultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultParameterReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>
    {
        public KeyVaultParameterReference(Azure.Core.ResourceIdentifier keyVaultId, string secretName) { }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        public string SecretName { get { throw null; } set { } }
        public string SecretVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Resources.DeploymentStacks.Models.KeyVaultParameterReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceStatusMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceStatusMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode DeleteFailed { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode Managed { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode RemoveDenyFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourceStatusMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourcesWithoutDeleteSupportAction : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourcesWithoutDeleteSupportAction(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction Detach { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction Fail { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction left, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction left, Azure.ResourceManager.Resources.DeploymentStacks.Models.ResourcesWithoutDeleteSupportAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionManagementGroupMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionManagementGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionManagementGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceGroupMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceGroupMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceGroupMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UnmanageActionResourceMode : System.IEquatable<Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UnmanageActionResourceMode(string value) { throw null; }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode Delete { get { throw null; } }
        public static Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode Detach { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode left, Azure.ResourceManager.Resources.DeploymentStacks.Models.UnmanageActionResourceMode right) { throw null; }
        public override string ToString() { throw null; }
    }
}
