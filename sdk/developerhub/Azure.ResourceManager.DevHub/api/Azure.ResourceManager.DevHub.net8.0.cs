namespace Azure.ResourceManager.DevHub
{
    public partial class AdoOAuthResponseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>
    {
        internal AdoOAuthResponseData() { }
        public string AdoOAuthUsername { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.AdoOAuthResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.AdoOAuthResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdoOAuthResponseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AdoOAuthResponseResource() { }
        public virtual Azure.ResourceManager.DevHub.AdoOAuthResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.AdoOAuthResponseResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult> GetAdoOAuthInfo(Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>> GetAdoOAuthInfoAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.AdoOAuthResponseResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevHub.AdoOAuthResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.AdoOAuthResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.AdoOAuthResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureResourceManagerDevHubContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDevHubContext() { }
        public static Azure.ResourceManager.DevHub.AzureResourceManagerDevHubContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DevHubExtensions
    {
        public static Azure.Response<System.Collections.Generic.IDictionary<string, string>> GeneratePreviewArtifacts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, string>>> GeneratePreviewArtifactsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponse(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.Models.OperationListResult> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.OperationListResult>> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource> GetDevHubTemplate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource>> GetDevHubTemplateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubTemplateResource GetDevHubTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubTemplateCollection GetDevHubTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> GetDevHubWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubWorkflowResource GetDevHubWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubWorkflowCollection GetDevHubWorkflows(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflows(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflowsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult> GetGitHubOAuth(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>> GetGitHubOAuthAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponse(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> GetIacProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.IacProfileResource GetIacProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevHub.IacProfileCollection GetIacProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.VersionedTemplateResource GetVersionedTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DevHubTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.DevHubTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.DevHubTemplateResource>, System.Collections.IEnumerable
    {
        protected DevHubTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource> Get(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.DevHubTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.DevHubTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource>> GetAsync(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevHub.DevHubTemplateResource> GetIfExists(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevHub.DevHubTemplateResource>> GetIfExistsAsync(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevHub.DevHubTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.DevHubTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevHub.DevHubTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.DevHubTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevHubTemplateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>
    {
        internal DevHubTemplateData() { }
        public Azure.ResourceManager.DevHub.Models.TemplateProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.DevHubTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.DevHubTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevHubTemplateResource() { }
        public virtual Azure.ResourceManager.DevHub.DevHubTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string templateName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.VersionedTemplateResource> GetVersionedTemplate(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.VersionedTemplateResource>> GetVersionedTemplateAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.VersionedTemplateCollection GetVersionedTemplates() { throw null; }
        Azure.ResourceManager.DevHub.DevHubTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.DevHubTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubWorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.DevHubWorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.DevHubWorkflowResource>, System.Collections.IEnumerable
    {
        protected DevHubWorkflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.DevHubWorkflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.DevHub.DevHubWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.DevHub.DevHubWorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> Get(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetAll(string managedClusterResource = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetAllAsync(string managedClusterResource = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> GetAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetIfExists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> GetIfExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevHub.DevHubWorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.DevHubWorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevHub.DevHubWorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.DevHubWorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevHubWorkflowData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>
    {
        public DevHubWorkflowData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevHub.Models.WorkflowProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.DevHubWorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.DevHubWorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubWorkflowResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevHubWorkflowResource() { }
        public virtual Azure.ResourceManager.DevHub.DevHubWorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevHub.DevHubWorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.DevHubWorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubWorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> Update(Azure.ResourceManager.DevHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> UpdateAsync(Azure.ResourceManager.DevHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GitHubOAuthResponseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>
    {
        internal GitHubOAuthResponseData() { }
        public string GitHubOAuthUsername { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.GitHubOAuthResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.GitHubOAuthResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubOAuthResponseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GitHubOAuthResponseResource() { }
        public virtual Azure.ResourceManager.DevHub.GitHubOAuthResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.GitHubOAuthResponseResource> Get(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.GitHubOAuthResponseResource>> GetAsync(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult> GitHubOAuth(Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>> GitHubOAuthAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevHub.GitHubOAuthResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.GitHubOAuthResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.GitHubOAuthResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.IacProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.IacProfileResource>, System.Collections.IEnumerable
    {
        protected IacProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.IacProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string iacProfileName, Azure.ResourceManager.DevHub.IacProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.IacProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string iacProfileName, Azure.ResourceManager.DevHub.IacProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> Get(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.IacProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.IacProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> GetAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevHub.IacProfileResource> GetIfExists(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevHub.IacProfileResource>> GetIfExistsAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevHub.IacProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.IacProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevHub.IacProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.IacProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IacProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>
    {
        public IacProfileData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DevHub.Models.AuthorizationStatus? AuthStatus { get { throw null; } }
        public string BranchName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.PullRequestStatus? PrStatus { get { throw null; } }
        public int? PullNumber { get { throw null; } }
        public string RepositoryMainBranch { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RepositoryOwner { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.StageProperties> Stages { get { throw null; } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageAccountResourceGroup { get { throw null; } set { } }
        public string StorageAccountSubscription { get { throw null; } set { } }
        public string StorageContainerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.IacTemplateProperties> Templates { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.IacProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.IacProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IacProfileResource() { }
        public virtual Azure.ResourceManager.DevHub.IacProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string iacProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult> Export(Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>> ExportAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult> Scale(Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>> ScaleAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Sync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevHub.IacProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.IacProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> Update(Azure.ResourceManager.DevHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> UpdateAsync(Azure.ResourceManager.DevHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VersionedTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.VersionedTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.VersionedTemplateResource>, System.Collections.IEnumerable
    {
        protected VersionedTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.VersionedTemplateResource> Get(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.VersionedTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.VersionedTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.VersionedTemplateResource>> GetAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevHub.VersionedTemplateResource> GetIfExists(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevHub.VersionedTemplateResource>> GetIfExistsAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevHub.VersionedTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.VersionedTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevHub.VersionedTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.VersionedTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VersionedTemplateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.VersionedTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>
    {
        internal VersionedTemplateData() { }
        public Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.VersionedTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.VersionedTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionedTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.VersionedTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VersionedTemplateResource() { }
        public virtual Azure.ResourceManager.DevHub.VersionedTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string templateName, string templateVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult> Generate(System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>> GenerateAsync(System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.VersionedTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.VersionedTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevHub.VersionedTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.VersionedTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.VersionedTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DevHub.Mocking
{
    public partial class MockableDevHubArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDevHubArmClient() { }
        public virtual Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubTemplateResource GetDevHubTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubWorkflowResource GetDevHubWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.IacProfileResource GetIacProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.VersionedTemplateResource GetVersionedTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDevHubResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevHubResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflow(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> GetDevHubWorkflowAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubWorkflowCollection GetDevHubWorkflows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfile(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> GetIacProfileAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.IacProfileCollection GetIacProfiles() { throw null; }
    }
    public partial class MockableDevHubSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevHubSubscriptionResource() { }
        public virtual Azure.Response<System.Collections.Generic.IDictionary<string, string>> GeneratePreviewArtifacts(string location, Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, string>>> GeneratePreviewArtifactsAsync(string location, Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponse() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource> GetDevHubTemplate(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource>> GetDevHubTemplateAsync(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubTemplateCollection GetDevHubTemplates() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflows(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflowsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult> GetGitHubOAuth(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>> GetGitHubOAuthAsync(string location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponse() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableDevHubTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevHubTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.OperationListResult> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.OperationListResult>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevHub.Models
{
    public partial class Acr : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Acr>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Acr>
    {
        public Acr() { }
        public string AcrRegistryName { get { throw null; } set { } }
        public string AcrRepositoryName { get { throw null; } set { } }
        public string AcrResourceGroup { get { throw null; } set { } }
        public string AcrSubscriptionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.Acr JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.Acr PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.Acr System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Acr>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Acr>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.Acr System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Acr>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Acr>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Acr>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionType : System.IEquatable<Azure.ResourceManager.DevHub.Models.ActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ActionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.ActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.ActionType left, Azure.ResourceManager.DevHub.Models.ActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ActionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ActionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.ActionType left, Azure.ResourceManager.DevHub.Models.ActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AdoProviderProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AdoProviderProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoProviderProfile>
    {
        public AdoProviderProfile() { }
        public string ArmServiceConnection { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.AdoRepository Repository { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.AdoProviderProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.AdoProviderProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.AdoProviderProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AdoProviderProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AdoProviderProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.AdoProviderProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoProviderProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoProviderProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoProviderProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AdoRepository : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AdoRepository>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoRepository>
    {
        public AdoRepository() { }
        public string AdoOrganization { get { throw null; } set { } }
        public string BranchName { get { throw null; } set { } }
        public string ProjectName { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RepositoryOwner { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.AdoRepository JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.AdoRepository PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.AdoRepository System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AdoRepository>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AdoRepository>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.AdoRepository System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoRepository>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoRepository>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AdoRepository>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDevHubModelFactory
    {
        public static Azure.ResourceManager.DevHub.Models.Acr Acr(string acrSubscriptionId = null, string acrResourceGroup = null, string acrRegistryName = null, string acrRepositoryName = null) { throw null; }
        public static Azure.ResourceManager.DevHub.AdoOAuthResponseData AdoOAuthResponseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string adoOAuthUsername = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.AdoProviderProfile AdoProviderProfile(Azure.ResourceManager.DevHub.Models.AdoRepository repository = null, string armServiceConnection = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.AdoRepository AdoRepository(string repositoryOwner = null, string repositoryName = null, string branchName = null, string adoOrganization = null, string projectName = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties ArtifactGenerationProperties(Azure.ResourceManager.DevHub.Models.GenerationLanguage? generationLanguage = default(Azure.ResourceManager.DevHub.Models.GenerationLanguage?), string languageVersion = null, string builderVersion = null, string port = null, string appName = null, string dockerfileOutputDirectory = null, string manifestOutputDirectory = null, Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode? dockerfileGenerationMode = default(Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode?), Azure.ResourceManager.DevHub.Models.ManifestGenerationMode? manifestGenerationMode = default(Azure.ResourceManager.DevHub.Models.ManifestGenerationMode?), Azure.ResourceManager.DevHub.Models.GenerationManifestType? manifestType = default(Azure.ResourceManager.DevHub.Models.GenerationManifestType?), string imageName = null, string @namespace = null, string imageTag = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.AzurePipelineProfile AzurePipelineProfile(Azure.ResourceManager.DevHub.Models.AdoRepository repository = null, string armServiceConnection = null, Azure.ResourceManager.DevHub.Models.Build build = null, Azure.ResourceManager.DevHub.Models.Deployment deployment = null, string @namespace = null, Azure.Core.ResourceIdentifier acr = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent pullRequest = null, Azure.ResourceManager.DevHub.Models.WorkflowRun lastWorkflowRun = null, Azure.ResourceManager.DevHub.Models.AuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.AuthorizationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.Build Build(string dockerfile = null, string dockerBuildContext = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.Deployment Deployment(Azure.ResourceManager.DevHub.Models.ManifestType? manifestType = default(Azure.ResourceManager.DevHub.Models.ManifestType?), System.Collections.Generic.IEnumerable<string> kubeManifestLocations = null, string helmChartPath = null, string helmValues = null, System.Collections.Generic.IDictionary<string, string> overrides = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent DeveloperHubAdoOAuthCallRequestContent(string redirectUri = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult DeveloperHubAdoOAuthInfoResponseResult(string authUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult DeveloperHubDeleteWorkflowResponseResult(string status = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent DeveloperHubExportTemplateRequestContent(string templateName = null, System.Collections.Generic.IEnumerable<string> resourceGroupIds = null, string siteId = null, string instanceName = null, string instanceStage = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult DeveloperHubGenerateVersionedTemplateResponseResult(System.Collections.Generic.IDictionary<string, string> generatedFiles = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent DeveloperHubGitHubOAuthCallRequestContent(string redirectUri = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult DeveloperHubGitHubOAuthInfoResponseResult(string authUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult DeveloperHubGitHubOAuthListResponseResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.GitHubOAuthResponseData> value = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo DeveloperHubOperationInfo(string name = null, bool? isDataAction = default(bool?), Azure.ResourceManager.DevHub.Models.OperationDisplay display = null, Azure.ResourceManager.DevHub.Models.Origin? origin = default(Azure.ResourceManager.DevHub.Models.Origin?), Azure.ResourceManager.DevHub.Models.ActionType? actionType = default(Azure.ResourceManager.DevHub.Models.ActionType?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent DeveloperHubParameterContent(string name = null, string description = null, Azure.ResourceManager.DevHub.Models.ParameterType? parameterType = default(Azure.ResourceManager.DevHub.Models.ParameterType?), Azure.ResourceManager.DevHub.Models.ParameterKind? parameterKind = default(Azure.ResourceManager.DevHub.Models.ParameterKind?), bool? isRequired = default(bool?), Azure.ResourceManager.DevHub.Models.ParameterDefault @default = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult DeveloperHubPrLinkResponseResult(string prLink = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent DeveloperHubPullRequestContent(string prUri = null, int? pullNumber = default(int?), Azure.ResourceManager.DevHub.Models.PullRequestStatus? prStatus = default(Azure.ResourceManager.DevHub.Models.PullRequestStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent DeveloperHubScaleTemplateRequestContent(string templateName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.ScaleProperty> scaleRequirement = null) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubTemplateData DevHubTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevHub.Models.TemplateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubWorkflowData DevHubWorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevHub.Models.WorkflowProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevHub.GitHubOAuthResponseData GitHubOAuthResponseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string gitHubOAuthUsername = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubProviderProfile GitHubProviderProfile(Azure.ResourceManager.DevHub.Models.GitHubRepository repository = null, Azure.ResourceManager.DevHub.Models.OidcCredentials oidcCredentials = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubRepository GitHubRepository(string repositoryOwner = null, string repositoryName = null, string branchName = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile GitHubWorkflowProfile(string repositoryOwner = null, string repositoryName = null, string branchName = null, string dockerfile = null, string dockerBuildContext = null, Azure.ResourceManager.DevHub.Models.Deployment deploymentProperties = null, string @namespace = null, Azure.ResourceManager.DevHub.Models.Acr acr = null, Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials oidcCredentials = null, Azure.Core.ResourceIdentifier aksResourceId = null, string prUri = null, int? pullNumber = default(int?), Azure.ResourceManager.DevHub.Models.PullRequestStatus? prStatus = default(Azure.ResourceManager.DevHub.Models.PullRequestStatus?), Azure.ResourceManager.DevHub.Models.WorkflowRun lastWorkflowRun = null, Azure.ResourceManager.DevHub.Models.AuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.AuthorizationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials GitHubWorkflowProfileOidcCredentials(string azureClientId = null, string azureTenantId = null) { throw null; }
        public static Azure.ResourceManager.DevHub.IacProfileData IacProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.StageProperties> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.IacTemplateProperties> templates = null, string repositoryName = null, string repositoryMainBranch = null, string repositoryOwner = null, Azure.ResourceManager.DevHub.Models.AuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.AuthorizationStatus?), int? pullNumber = default(int?), Azure.ResourceManager.DevHub.Models.PullRequestStatus? prStatus = default(Azure.ResourceManager.DevHub.Models.PullRequestStatus?), string branchName = null, string storageAccountSubscription = null, string storageAccountResourceGroup = null, string storageAccountName = null, string storageContainerName = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.IacTemplateDetails IacTemplateDetails(string productName = null, int? count = default(int?), string namingConvention = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.IacTemplateProperties IacTemplateProperties(string templateName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, string instanceStage = null, string instanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.IacTemplateDetails> templateDetails = null, Azure.ResourceManager.DevHub.Models.QuickStartTemplateType? quickStartTemplateType = default(Azure.ResourceManager.DevHub.Models.QuickStartTemplateType?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.OidcCredentials OidcCredentials(string azureClientId = null, string azureTenantId = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.OperationDisplay OperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.OperationListResult OperationListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ParameterDefault ParameterDefault(string value = null, string referenceParameter = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ScaleProperty ScaleProperty(string region = null, string stage = null, int? numberOfStore = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.StageProperties StageProperties(string stageName = null, System.Collections.Generic.IEnumerable<string> dependencies = null, string gitEnvironment = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.TagsObject TagsObject(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.TemplateProperties TemplateProperties(string templateName = null, string defaultVersion = null, System.Collections.Generic.IEnumerable<string> versions = null, string description = null, Azure.ResourceManager.DevHub.Models.TemplateType? templateType = default(Azure.ResourceManager.DevHub.Models.TemplateType?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.TemplateReference TemplateReference(Azure.Core.ResourceIdentifier templateId = null, string destination = null, System.Collections.Generic.IDictionary<string, string> parameters = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile TemplateWorkflowProfile(Azure.ResourceManager.DevHub.Models.RepositoryProviderType? repositoryProvider = default(Azure.ResourceManager.DevHub.Models.RepositoryProviderType?), Azure.ResourceManager.DevHub.Models.TemplateReference workflowTemplate = null, Azure.ResourceManager.DevHub.Models.TemplateReference deploymentTemplate = null, Azure.ResourceManager.DevHub.Models.TemplateReference dockerfileTemplate = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.TemplateReference> manifestTemplates = null, Azure.ResourceManager.DevHub.Models.GitHubProviderProfile gitHubProviderProfile = null, Azure.ResourceManager.DevHub.Models.AdoProviderProfile adoProviderProfile = null, Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent pullRequest = null, Azure.ResourceManager.DevHub.Models.WorkflowRun lastWorkflowRun = null, Azure.ResourceManager.DevHub.Models.AuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.AuthorizationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.VersionedTemplateData VersionedTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties VersionedTemplateProperties(string version = null, Azure.ResourceManager.DevHub.Models.TemplateType? templateType = default(Azure.ResourceManager.DevHub.Models.TemplateType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent> parameters = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.WorkflowProperties WorkflowProperties(Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile githubWorkflowProfile = null, Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties artifactGenerationProperties = null, Azure.ResourceManager.DevHub.Models.AzurePipelineProfile azurePipelineProfile = null, Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile templateWorkflowProfile = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.WorkflowRun WorkflowRun(bool? isSucceeded = default(bool?), string workflowRunUri = null, System.DateTimeOffset? lastRunOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevHub.Models.WorkflowRunStatus? workflowRunStatus = default(Azure.ResourceManager.DevHub.Models.WorkflowRunStatus?)) { throw null; }
    }
    public partial class ArtifactGenerationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties>
    {
        public ArtifactGenerationProperties() { }
        public string AppName { get { throw null; } set { } }
        public string BuilderVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode? DockerfileGenerationMode { get { throw null; } set { } }
        public string DockerfileOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GenerationLanguage? GenerationLanguage { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public string ImageTag { get { throw null; } set { } }
        public string LanguageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.ManifestGenerationMode? ManifestGenerationMode { get { throw null; } set { } }
        public string ManifestOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GenerationManifestType? ManifestType { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthorizationStatus : System.IEquatable<Azure.ResourceManager.DevHub.Models.AuthorizationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthorizationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.AuthorizationStatus Authorized { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.AuthorizationStatus Error { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.AuthorizationStatus NotFound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.AuthorizationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.AuthorizationStatus left, Azure.ResourceManager.DevHub.Models.AuthorizationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.AuthorizationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.AuthorizationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.AuthorizationStatus left, Azure.ResourceManager.DevHub.Models.AuthorizationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzurePipelineProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>
    {
        public AzurePipelineProfile() { }
        public Azure.Core.ResourceIdentifier Acr { get { throw null; } set { } }
        public string ArmServiceConnection { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.AuthorizationStatus? AuthStatus { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.Build Build { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.Deployment Deployment { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.WorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent PullRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.AdoRepository Repository { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.AzurePipelineProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.AzurePipelineProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.AzurePipelineProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.AzurePipelineProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Build : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Build>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Build>
    {
        public Build() { }
        public string DockerBuildContext { get { throw null; } set { } }
        public string Dockerfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.Build JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.Build PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.Build System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Build>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Build>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.Build System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Build>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Build>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Build>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Deployment : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Deployment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Deployment>
    {
        public Deployment() { }
        public string HelmChartPath { get { throw null; } set { } }
        public string HelmValues { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KubeManifestLocations { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.ManifestType? ManifestType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Overrides { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.Deployment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.Deployment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.Deployment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Deployment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.Deployment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.Deployment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Deployment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Deployment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.Deployment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubAdoOAuthCallRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent>
    {
        public DeveloperHubAdoOAuthCallRequestContent() { }
        public string RedirectUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubAdoOAuthInfoResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>
    {
        internal DeveloperHubAdoOAuthInfoResponseResult() { }
        public string AuthUri { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubDeleteWorkflowResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>
    {
        internal DeveloperHubDeleteWorkflowResponseResult() { }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubExportTemplateRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent>
    {
        public DeveloperHubExportTemplateRequestContent() { }
        public string InstanceName { get { throw null; } set { } }
        public string InstanceStage { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGroupIds { get { throw null; } }
        public string SiteId { get { throw null; } set { } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGenerateVersionedTemplateResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>
    {
        internal DeveloperHubGenerateVersionedTemplateResponseResult() { }
        public System.Collections.Generic.IDictionary<string, string> GeneratedFiles { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGitHubOAuthCallRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent>
    {
        public DeveloperHubGitHubOAuthCallRequestContent() { }
        public string RedirectUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGitHubOAuthInfoResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>
    {
        internal DeveloperHubGitHubOAuthInfoResponseResult() { }
        public string AuthUri { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGitHubOAuthListResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>
    {
        internal DeveloperHubGitHubOAuthListResponseResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.GitHubOAuthResponseData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>
    {
        internal DeveloperHubOperationInfo() { }
        public Azure.ResourceManager.DevHub.Models.ActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.OperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.Origin? Origin { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubParameterContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent>
    {
        internal DeveloperHubParameterContent() { }
        public Azure.ResourceManager.DevHub.Models.ParameterDefault Default { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.ParameterKind? ParameterKind { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.ParameterType? ParameterType { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubPrLinkResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>
    {
        internal DeveloperHubPrLinkResponseResult() { }
        public string PrLink { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubPullRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>
    {
        public DeveloperHubPullRequestContent() { }
        public Azure.ResourceManager.DevHub.Models.PullRequestStatus? PrStatus { get { throw null; } }
        public string PrUri { get { throw null; } }
        public int? PullNumber { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubScaleTemplateRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent>
    {
        public DeveloperHubScaleTemplateRequestContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.ScaleProperty> ScaleRequirement { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateRequestContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DockerfileGenerationMode : System.IEquatable<Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DockerfileGenerationMode(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode left, Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode left, Azure.ResourceManager.DevHub.Models.DockerfileGenerationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerationLanguage : System.IEquatable<Azure.ResourceManager.DevHub.Models.GenerationLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerationLanguage(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Clojure { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Csharp { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Erlang { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Go { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage GoModule { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Gradle { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Java { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Javascript { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Php { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Python { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Ruby { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Rust { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationLanguage Swift { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.GenerationLanguage other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.GenerationLanguage left, Azure.ResourceManager.DevHub.Models.GenerationLanguage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.GenerationLanguage (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.GenerationLanguage? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.GenerationLanguage left, Azure.ResourceManager.DevHub.Models.GenerationLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerationManifestType : System.IEquatable<Azure.ResourceManager.DevHub.Models.GenerationManifestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerationManifestType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GenerationManifestType Helm { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.GenerationManifestType Kube { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.GenerationManifestType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.GenerationManifestType left, Azure.ResourceManager.DevHub.Models.GenerationManifestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.GenerationManifestType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.GenerationManifestType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.GenerationManifestType left, Azure.ResourceManager.DevHub.Models.GenerationManifestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GitHubProviderProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>
    {
        public GitHubProviderProfile() { }
        public Azure.ResourceManager.DevHub.Models.OidcCredentials OidcCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GitHubRepository Repository { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubProviderProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubProviderProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.GitHubProviderProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.GitHubProviderProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubRepository : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubRepository>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubRepository>
    {
        public GitHubRepository() { }
        public string BranchName { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RepositoryOwner { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubRepository JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubRepository PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.GitHubRepository System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubRepository>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubRepository>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.GitHubRepository System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubRepository>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubRepository>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubRepository>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubWorkflowProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile>
    {
        public GitHubWorkflowProfile() { }
        public Azure.ResourceManager.DevHub.Models.Acr Acr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AksResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.AuthorizationStatus? AuthStatus { get { throw null; } }
        public string BranchName { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.Deployment DeploymentProperties { get { throw null; } set { } }
        public string DockerBuildContext { get { throw null; } set { } }
        public string Dockerfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.WorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials OidcCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.PullRequestStatus? PrStatus { get { throw null; } }
        public string PrUri { get { throw null; } }
        public int? PullNumber { get { throw null; } }
        public string RepositoryName { get { throw null; } set { } }
        public string RepositoryOwner { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubWorkflowProfileOidcCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials>
    {
        public GitHubWorkflowProfileOidcCredentials() { }
        public string AzureClientId { get { throw null; } set { } }
        public string AzureTenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacTemplateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.IacTemplateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateDetails>
    {
        public IacTemplateDetails() { }
        public int? Count { get { throw null; } set { } }
        public string NamingConvention { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.IacTemplateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.IacTemplateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.IacTemplateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.IacTemplateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.IacTemplateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.IacTemplateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.IacTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateProperties>
    {
        public IacTemplateProperties() { }
        public string InstanceName { get { throw null; } set { } }
        public string InstanceStage { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.QuickStartTemplateType? QuickStartTemplateType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.IacTemplateDetails> TemplateDetails { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.IacTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.IacTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.IacTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.IacTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.IacTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.IacTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.IacTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManifestGenerationMode : System.IEquatable<Azure.ResourceManager.DevHub.Models.ManifestGenerationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManifestGenerationMode(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ManifestGenerationMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ManifestGenerationMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.ManifestGenerationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.ManifestGenerationMode left, Azure.ResourceManager.DevHub.Models.ManifestGenerationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ManifestGenerationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ManifestGenerationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.ManifestGenerationMode left, Azure.ResourceManager.DevHub.Models.ManifestGenerationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManifestType : System.IEquatable<Azure.ResourceManager.DevHub.Models.ManifestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManifestType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ManifestType Helm { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ManifestType Kube { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ManifestType Kustomize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.ManifestType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.ManifestType left, Azure.ResourceManager.DevHub.Models.ManifestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ManifestType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ManifestType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.ManifestType left, Azure.ResourceManager.DevHub.Models.ManifestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OidcCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OidcCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OidcCredentials>
    {
        public OidcCredentials() { }
        public string AzureClientId { get { throw null; } set { } }
        public string AzureTenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.OidcCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.OidcCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.OidcCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OidcCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OidcCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.OidcCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OidcCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OidcCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OidcCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationDisplay>
    {
        internal OperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.OperationDisplay JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.OperationDisplay PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.OperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.OperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OperationListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OperationListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationListResult>
    {
        internal OperationListResult() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.OperationListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.OperationListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.OperationListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OperationListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.OperationListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.OperationListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.OperationListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Origin : System.IEquatable<Azure.ResourceManager.DevHub.Models.Origin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Origin(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.Origin System { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.Origin User { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.Origin UserSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.Origin other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.Origin left, Azure.ResourceManager.DevHub.Models.Origin right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.Origin (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.Origin? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.Origin left, Azure.ResourceManager.DevHub.Models.Origin right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ParameterDefault : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ParameterDefault>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ParameterDefault>
    {
        internal ParameterDefault() { }
        public string ReferenceParameter { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.ParameterDefault JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.ParameterDefault PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.ParameterDefault System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ParameterDefault>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ParameterDefault>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.ParameterDefault System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ParameterDefault>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ParameterDefault>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ParameterDefault>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterKind : System.IEquatable<Azure.ResourceManager.DevHub.Models.ParameterKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterKind(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind AzureContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind AzureKeyvaultUri { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind AzureManagedCluster { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind AzureResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind AzureServiceConnection { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ClusterResourceType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ContainerImageName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ContainerImageVersion { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind DirPath { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind DockerFileName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind EnvVarMap { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind FilePath { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind Flag { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind HelmChartOverrides { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ImagePullPolicy { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind IngressHostName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesNamespace { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesProbeDelay { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesProbeHttpPath { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesProbePeriod { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesProbeThreshold { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesProbeTimeout { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesProbeType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesResourceLimit { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesResourceName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind KubernetesResourceRequest { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind Label { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind Port { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ReplicaCount { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind RepositoryBranch { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ResourceLimit { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ScalingResourceType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind ScalingResourceUtilization { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind WorkflowAuthType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterKind WorkflowName { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.ParameterKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.ParameterKind left, Azure.ResourceManager.DevHub.Models.ParameterKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ParameterKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ParameterKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.ParameterKind left, Azure.ResourceManager.DevHub.Models.ParameterKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ParameterType : System.IEquatable<Azure.ResourceManager.DevHub.Models.ParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.ParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.ParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.ParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.ParameterType left, Azure.ResourceManager.DevHub.Models.ParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.ParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.ParameterType left, Azure.ResourceManager.DevHub.Models.ParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PullRequestStatus : System.IEquatable<Azure.ResourceManager.DevHub.Models.PullRequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PullRequestStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.PullRequestStatus Merged { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.PullRequestStatus Removed { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.PullRequestStatus Submitted { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.PullRequestStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.PullRequestStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.PullRequestStatus left, Azure.ResourceManager.DevHub.Models.PullRequestStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.PullRequestStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.PullRequestStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.PullRequestStatus left, Azure.ResourceManager.DevHub.Models.PullRequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuickStartTemplateType : System.IEquatable<Azure.ResourceManager.DevHub.Models.QuickStartTemplateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuickStartTemplateType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.QuickStartTemplateType HCI { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.QuickStartTemplateType HciAks { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.QuickStartTemplateType HciArcVm { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.QuickStartTemplateType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.QuickStartTemplateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.QuickStartTemplateType left, Azure.ResourceManager.DevHub.Models.QuickStartTemplateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.QuickStartTemplateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.QuickStartTemplateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.QuickStartTemplateType left, Azure.ResourceManager.DevHub.Models.QuickStartTemplateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RepositoryProviderType : System.IEquatable<Azure.ResourceManager.DevHub.Models.RepositoryProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RepositoryProviderType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.RepositoryProviderType Ado { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.RepositoryProviderType Github { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.RepositoryProviderType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.RepositoryProviderType left, Azure.ResourceManager.DevHub.Models.RepositoryProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.RepositoryProviderType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.RepositoryProviderType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.RepositoryProviderType left, Azure.ResourceManager.DevHub.Models.RepositoryProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScaleProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ScaleProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ScaleProperty>
    {
        public ScaleProperty() { }
        public int? NumberOfStore { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string Stage { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.ScaleProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.ScaleProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.ScaleProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ScaleProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.ScaleProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.ScaleProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ScaleProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ScaleProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.ScaleProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.StageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.StageProperties>
    {
        public StageProperties() { }
        public System.Collections.Generic.IList<string> Dependencies { get { throw null; } }
        public string GitEnvironment { get { throw null; } set { } }
        public string StageName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.StageProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.StageProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.StageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.StageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.StageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.StageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.StageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.StageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.StageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TagsObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TagsObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TagsObject>
    {
        public TagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.TagsObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.TagsObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.TagsObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TagsObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TagsObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.TagsObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TagsObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TagsObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TagsObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateProperties>
    {
        internal TemplateProperties() { }
        public string DefaultVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public string TemplateName { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.TemplateType? TemplateType { get { throw null; } }
        public System.Collections.Generic.IList<string> Versions { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.TemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.TemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.TemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.TemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TemplateReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateReference>
    {
        public TemplateReference() { }
        public string Destination { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.Core.ResourceIdentifier TemplateId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.TemplateReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.TemplateReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.TemplateReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.TemplateReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemplateType : System.IEquatable<Azure.ResourceManager.DevHub.Models.TemplateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemplateType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.TemplateType Deployment { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.TemplateType Dockerfile { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.TemplateType Manifest { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.TemplateType Workflow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.TemplateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.TemplateType left, Azure.ResourceManager.DevHub.Models.TemplateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.TemplateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.TemplateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.TemplateType left, Azure.ResourceManager.DevHub.Models.TemplateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemplateWorkflowProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile>
    {
        public TemplateWorkflowProfile() { }
        public Azure.ResourceManager.DevHub.Models.AdoProviderProfile AdoProviderProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.AuthorizationStatus? AuthStatus { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.TemplateReference DeploymentTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.TemplateReference DockerfileTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GitHubProviderProfile GitHubProviderProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.WorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.TemplateReference> ManifestTemplates { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent PullRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.RepositoryProviderType? RepositoryProvider { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.TemplateReference WorkflowTemplate { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionedTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties>
    {
        internal VersionedTemplateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent> Parameters { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.TemplateType? TemplateType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.VersionedTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.WorkflowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowProperties>
    {
        public WorkflowProperties() { }
        public Azure.ResourceManager.DevHub.Models.ArtifactGenerationProperties ArtifactGenerationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.AzurePipelineProfile AzurePipelineProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile GithubWorkflowProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.TemplateWorkflowProfile TemplateWorkflowProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.WorkflowProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.WorkflowProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.WorkflowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.WorkflowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.WorkflowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.WorkflowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowRun : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.WorkflowRun>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowRun>
    {
        public WorkflowRun() { }
        public bool? IsSucceeded { get { throw null; } }
        public System.DateTimeOffset? LastRunOn { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.WorkflowRunStatus? WorkflowRunStatus { get { throw null; } }
        public string WorkflowRunUri { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.WorkflowRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.WorkflowRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.WorkflowRun System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.WorkflowRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.WorkflowRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.WorkflowRun System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.WorkflowRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowRunStatus : System.IEquatable<Azure.ResourceManager.DevHub.Models.WorkflowRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.WorkflowRunStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.WorkflowRunStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.WorkflowRunStatus Queued { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.WorkflowRunStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.WorkflowRunStatus left, Azure.ResourceManager.DevHub.Models.WorkflowRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.WorkflowRunStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.WorkflowRunStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.WorkflowRunStatus left, Azure.ResourceManager.DevHub.Models.WorkflowRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
