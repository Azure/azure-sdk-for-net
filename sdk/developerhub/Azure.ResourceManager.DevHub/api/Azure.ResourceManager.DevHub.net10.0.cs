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
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult> GetAdoOAuthInfo(Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>> GetAdoOAuthInfoAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.Response<System.Collections.Generic.IDictionary<string, string>> GeneratePreviewArtifacts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties devHubArtifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, string>>> GeneratePreviewArtifactsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties devHubArtifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponse(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult> GetAll(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>> GetAllAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource> GetDevHubTemplate(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource>> GetDevHubTemplateAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubTemplateResource GetDevHubTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubTemplateCollection GetDevHubTemplates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource GetDevHubVersionedTemplateResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> GetDevHubWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubWorkflowResource GetDevHubWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubWorkflowCollection GetDevHubWorkflows(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflows(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflowsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult> GetGitHubOAuth(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>> GetGitHubOAuthAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponse(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> GetIacProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DevHub.IacProfileResource GetIacProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DevHub.IacProfileCollection GetIacProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties Properties { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> GetDevHubVersionedTemplate(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>> GetDevHubVersionedTemplateAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubVersionedTemplateCollection GetDevHubVersionedTemplates() { throw null; }
        Azure.ResourceManager.DevHub.DevHubTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.DevHubTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubVersionedTemplateCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>, System.Collections.IEnumerable
    {
        protected DevHubVersionedTemplateCollection() { }
        public virtual Azure.Response<bool> Exists(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> Get(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>> GetAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> GetIfExists(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>> GetIfExistsAsync(string templateVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DevHubVersionedTemplateData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>
    {
        internal DevHubVersionedTemplateData() { }
        public Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.DevHubVersionedTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.DevHubVersionedTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubVersionedTemplateResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DevHubVersionedTemplateResource() { }
        public virtual Azure.ResourceManager.DevHub.DevHubVersionedTemplateData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string templateName, string templateVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult> Generate(System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>> GenerateAsync(System.Collections.Generic.IDictionary<string, string> parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevHub.DevHubVersionedTemplateData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.DevHubVersionedTemplateData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.DevHubVersionedTemplateData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties Properties { get { throw null; } set { } }
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource> Update(Azure.ResourceManager.DevHub.Models.DevHubTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubWorkflowResource>> UpdateAsync(Azure.ResourceManager.DevHub.Models.DevHubTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult> GitHubOAuth(Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>> GitHubOAuthAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? AuthStatus { get { throw null; } }
        public string BranchName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus? PrStatus { get { throw null; } }
        public int? PullNumber { get { throw null; } }
        public string RepositoryMainBranch { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RepositoryOwner { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.DevHubStageInfo> Stages { get { throw null; } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageAccountResourceGroup { get { throw null; } set { } }
        public string StorageAccountSubscription { get { throw null; } set { } }
        public string StorageContainerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties> Templates { get { throw null; } }
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
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult> Export(Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>> ExportAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult> Scale(Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>> ScaleAsync(Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Sync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DevHub.IacProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.IacProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.IacProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.IacProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource> Update(Azure.ResourceManager.DevHub.Models.DevHubTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.IacProfileResource>> UpdateAsync(Azure.ResourceManager.DevHub.Models.DevHubTagsPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevHub.Mocking
{
    public partial class MockableDevHubArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDevHubArmClient() { }
        public virtual Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubTemplateResource GetDevHubTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubVersionedTemplateResource GetDevHubVersionedTemplateResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubWorkflowResource GetDevHubWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DevHub.IacProfileResource GetIacProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
        public virtual Azure.Response<System.Collections.Generic.IDictionary<string, string>> GeneratePreviewArtifacts(Azure.Core.AzureLocation location, Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties devHubArtifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IDictionary<string, string>>> GeneratePreviewArtifactsAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties devHubArtifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.AdoOAuthResponseResource GetAdoOAuthResponse() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource> GetDevHubTemplate(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.DevHubTemplateResource>> GetDevHubTemplateAsync(string templateName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.DevHubTemplateCollection GetDevHubTemplates() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflows(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.DevHubWorkflowResource> GetDevHubWorkflowsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult> GetGitHubOAuth(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>> GetGitHubOAuthAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DevHub.GitHubOAuthResponseResource GetGitHubOAuthResponse() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DevHub.IacProfileResource> GetIacProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableDevHubTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDevHubTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DevHub.Models
{
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
        public static Azure.ResourceManager.DevHub.AdoOAuthResponseData AdoOAuthResponseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string adoOAuthUsername = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.AdoProviderProfile AdoProviderProfile(Azure.ResourceManager.DevHub.Models.AdoRepository repository = null, string armServiceConnection = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.AdoRepository AdoRepository(string repositoryOwner = null, string repositoryName = null, string branchName = null, string adoOrganization = null, string projectName = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.AzurePipelineProfile AzurePipelineProfile(Azure.ResourceManager.DevHub.Models.AdoRepository repository = null, string armServiceConnection = null, Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo build = null, Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties deployment = null, string @namespace = null, Azure.Core.ResourceIdentifier acr = null, Azure.Core.ResourceIdentifier clusterId = null, Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent pullRequest = null, Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun lastWorkflowRun = null, Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent DeveloperHubAdoOAuthCallContent(string redirectUri = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult DeveloperHubAdoOAuthInfoResult(string authUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult DeveloperHubDeleteWorkflowResult(string status = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent DeveloperHubExportTemplateContent(string templateName = null, System.Collections.Generic.IEnumerable<string> resourceGroupIds = null, string siteId = null, string instanceName = null, string instanceStage = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult DeveloperHubGenerateVersionedTemplateResult(System.Collections.Generic.IDictionary<string, string> generatedFiles = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent DeveloperHubGitHubOAuthCallContent(string redirectUri = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult DeveloperHubGitHubOAuthInfoResult(string authUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult DeveloperHubGitHubOAuthListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.GitHubOAuthResponseData> value = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo DeveloperHubOperationInfo(string name = null, bool? isDataAction = default(bool?), Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay display = null, Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin? origin = default(Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin?), Azure.ResourceManager.DevHub.Models.DevHubActionType? actionType = default(Azure.ResourceManager.DevHub.Models.DevHubActionType?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent DeveloperHubParameterContent(string name = null, string description = null, Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType? parameterType = default(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType?), Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind? parameterKind = default(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind?), bool? isRequired = default(bool?), Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault @default = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult DeveloperHubPrLinkResult(string prLink = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent DeveloperHubPullRequestContent(string prUri = null, int? pullNumber = default(int?), Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus? prStatus = default(Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent DeveloperHubScaleTemplateContent(string templateName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty> scaleRequirement = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties DevHubArtifactGenerationProperties(Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage? generationLanguage = default(Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage?), string languageVersion = null, string builderVersion = null, string port = null, string appName = null, string dockerfileOutputDirectory = null, string manifestOutputDirectory = null, Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode? dockerfileGenerationMode = default(Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode?), Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode? manifestGenerationMode = default(Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode?), Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType? manifestType = default(Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType?), string imageName = null, string @namespace = null, string imageTag = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo DevHubContainerRegistryInfo(string acrSubscriptionId = null, string acrResourceGroup = null, string acrRegistryName = null, string acrRepositoryName = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties DevHubDeploymentProperties(Azure.ResourceManager.DevHub.Models.DevHubManifestType? manifestType = default(Azure.ResourceManager.DevHub.Models.DevHubManifestType?), System.Collections.Generic.IEnumerable<string> kubeManifestLocations = null, string helmChartPath = null, string helmValues = null, System.Collections.Generic.IDictionary<string, string> overrides = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo DevHubDockerBuildInfo(string dockerfile = null, string dockerBuildContext = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails DevHubIacTemplateDetails(string productName = null, int? count = default(int?), string namingConvention = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties DevHubIacTemplateProperties(string templateName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, string instanceStage = null, string instanceName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails> templateDetails = null, Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType? quickStartTemplateType = default(Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials DevHubOidcCredentials(string azureClientId = null, string azureTenantId = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay DevHubOperationDisplay(string provider = null, string resource = null, string operation = null, string description = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubOperationListResult DevHubOperationListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubScaleProperty DevHubScaleProperty(string region = null, string stage = null, int? numberOfStores = default(int?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubStageInfo DevHubStageInfo(string stageName = null, System.Collections.Generic.IEnumerable<string> dependencies = null, string gitEnvironment = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTagsPatch DevHubTagsPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubTemplateData DevHubTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault DevHubTemplateParameterDefault(string value = null, string referenceParameter = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties DevHubTemplateProperties(string templateName = null, string defaultVersion = null, System.Collections.Generic.IEnumerable<string> versions = null, string description = null, Azure.ResourceManager.DevHub.Models.DevHubTemplateType? templateType = default(Azure.ResourceManager.DevHub.Models.DevHubTemplateType?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateReference DevHubTemplateReference(Azure.Core.ResourceIdentifier templateId = null, string destination = null, System.Collections.Generic.IDictionary<string, string> parameters = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile DevHubTemplateWorkflowProfile(Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType? repositoryProvider = default(Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType?), Azure.ResourceManager.DevHub.Models.DevHubTemplateReference workflowTemplate = null, Azure.ResourceManager.DevHub.Models.DevHubTemplateReference deploymentTemplate = null, Azure.ResourceManager.DevHub.Models.DevHubTemplateReference dockerfileTemplate = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference> manifestTemplates = null, Azure.ResourceManager.DevHub.Models.GitHubProviderProfile gitHubProviderProfile = null, Azure.ResourceManager.DevHub.Models.AdoProviderProfile adoProviderProfile = null, Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent pullRequest = null, Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun lastWorkflowRun = null, Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubVersionedTemplateData DevHubVersionedTemplateData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties DevHubVersionedTemplateProperties(string version = null, Azure.ResourceManager.DevHub.Models.DevHubTemplateType? templateType = default(Azure.ResourceManager.DevHub.Models.DevHubTemplateType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent> parameters = null) { throw null; }
        public static Azure.ResourceManager.DevHub.DevHubWorkflowData DevHubWorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties properties = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties DevHubWorkflowProperties(Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile githubWorkflowProfile = null, Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties artifactGenerationProperties = null, Azure.ResourceManager.DevHub.Models.AzurePipelineProfile azurePipelineProfile = null, Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile templateWorkflowProfile = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun DevHubWorkflowRun(bool? isSucceeded = default(bool?), string workflowRunUri = null, System.DateTimeOffset? lastRunOn = default(System.DateTimeOffset?), Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus? workflowRunStatus = default(Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.GitHubOAuthResponseData GitHubOAuthResponseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string gitHubOAuthUsername = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubProviderProfile GitHubProviderProfile(Azure.ResourceManager.DevHub.Models.GitHubRepository repository = null, Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials oidcCredentials = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubRepository GitHubRepository(string repositoryOwner = null, string repositoryName = null, string branchName = null) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile GitHubWorkflowProfile(string repositoryOwner = null, string repositoryName = null, string branchName = null, string dockerfile = null, string dockerBuildContext = null, Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties deploymentProperties = null, string @namespace = null, Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo acr = null, Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials oidcCredentials = null, Azure.Core.ResourceIdentifier aksResourceId = null, string prUri = null, int? pullNumber = default(int?), Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus? prStatus = default(Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus?), Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun lastWorkflowRun = null, Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus?)) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials GitHubWorkflowProfileOidcCredentials(string azureClientId = null, string azureTenantId = null) { throw null; }
        public static Azure.ResourceManager.DevHub.IacProfileData IacProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DevHubStageInfo> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties> templates = null, string repositoryName = null, string repositoryMainBranch = null, string repositoryOwner = null, Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? authStatus = default(Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus?), int? pullNumber = default(int?), Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus? prStatus = default(Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus?), string branchName = null, string storageAccountSubscription = null, string storageAccountResourceGroup = null, string storageAccountName = null, string storageContainerName = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
    }
    public partial class AzurePipelineProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.AzurePipelineProfile>
    {
        public AzurePipelineProfile() { }
        public Azure.Core.ResourceIdentifier Acr { get { throw null; } set { } }
        public string ArmServiceConnection { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? AuthStatus { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo Build { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ClusterId { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties Deployment { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun LastWorkflowRun { get { throw null; } set { } }
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
    public partial class DeveloperHubAdoOAuthCallContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent>
    {
        public DeveloperHubAdoOAuthCallContent() { }
        public string RedirectUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthCallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubAdoOAuthInfoResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>
    {
        internal DeveloperHubAdoOAuthInfoResult() { }
        public string AuthUri { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubAdoOAuthInfoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubDeleteWorkflowResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>
    {
        internal DeveloperHubDeleteWorkflowResult() { }
        public string Status { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubDeleteWorkflowResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubExportTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent>
    {
        public DeveloperHubExportTemplateContent() { }
        public string InstanceName { get { throw null; } set { } }
        public string InstanceStage { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGroupIds { get { throw null; } }
        public string SiteId { get { throw null; } set { } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubExportTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGenerateVersionedTemplateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>
    {
        internal DeveloperHubGenerateVersionedTemplateResult() { }
        public System.Collections.Generic.IDictionary<string, string> GeneratedFiles { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGenerateVersionedTemplateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGitHubOAuthCallContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent>
    {
        public DeveloperHubGitHubOAuthCallContent() { }
        public string RedirectUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthCallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGitHubOAuthInfoResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>
    {
        internal DeveloperHubGitHubOAuthInfoResult() { }
        public string AuthUri { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthInfoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubGitHubOAuthListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>
    {
        internal DeveloperHubGitHubOAuthListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.GitHubOAuthResponseData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubGitHubOAuthListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubOperationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo>
    {
        internal DeveloperHubOperationInfo() { }
        public Azure.ResourceManager.DevHub.Models.DevHubActionType? ActionType { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay Display { get { throw null; } }
        public bool? IsDataAction { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin? Origin { get { throw null; } }
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
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault Default { get { throw null; } }
        public string Description { get { throw null; } }
        public bool? IsRequired { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind? ParameterKind { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType? ParameterType { get { throw null; } }
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
    public partial class DeveloperHubPrLinkResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>
    {
        internal DeveloperHubPrLinkResult() { }
        public string PrLink { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPrLinkResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeveloperHubPullRequestContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent>
    {
        public DeveloperHubPullRequestContent() { }
        public Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus? PrStatus { get { throw null; } }
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
    public partial class DeveloperHubScaleTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent>
    {
        public DeveloperHubScaleTemplateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty> ScaleRequirement { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DeveloperHubScaleTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubActionType : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubActionType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubActionType Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubActionType left, Azure.ResourceManager.DevHub.Models.DevHubActionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubActionType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubActionType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubActionType left, Azure.ResourceManager.DevHub.Models.DevHubActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevHubArtifactGenerationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties>
    {
        public DevHubArtifactGenerationProperties() { }
        public string AppName { get { throw null; } set { } }
        public string BuilderVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode? DockerfileGenerationMode { get { throw null; } set { } }
        public string DockerfileOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage? GenerationLanguage { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public string ImageTag { get { throw null; } set { } }
        public string LanguageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode? ManifestGenerationMode { get { throw null; } set { } }
        public string ManifestOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType? ManifestType { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubAuthorizationStatus : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubAuthorizationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus Authorized { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus Error { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus NotFound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus left, Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus left, Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevHubContainerRegistryInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo>
    {
        public DevHubContainerRegistryInfo() { }
        public string AcrRegistryName { get { throw null; } set { } }
        public string AcrRepositoryName { get { throw null; } set { } }
        public string AcrResourceGroup { get { throw null; } set { } }
        public string AcrSubscriptionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubDeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties>
    {
        public DevHubDeploymentProperties() { }
        public string HelmChartPath { get { throw null; } set { } }
        public string HelmValues { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KubeManifestLocations { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubManifestType? ManifestType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Overrides { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubDockerBuildInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo>
    {
        public DevHubDockerBuildInfo() { }
        public string DockerBuildContext { get { throw null; } set { } }
        public string Dockerfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubDockerBuildInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubDockerfileGenerationMode : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubDockerfileGenerationMode(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode left, Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode left, Azure.ResourceManager.DevHub.Models.DevHubDockerfileGenerationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubGenerationLanguage : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubGenerationLanguage(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Clojure { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage CSharp { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Erlang { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Go { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage GoModule { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Gradle { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Java { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage JavaScript { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Php { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Python { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Ruby { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Rust { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage Swift { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage left, Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage left, Azure.ResourceManager.DevHub.Models.DevHubGenerationLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubGenerationManifestType : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubGenerationManifestType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType Helm { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType Kube { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType left, Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType left, Azure.ResourceManager.DevHub.Models.DevHubGenerationManifestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevHubIacTemplateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails>
    {
        public DevHubIacTemplateDetails() { }
        public int? Count { get { throw null; } set { } }
        public string NamingConvention { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubIacTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties>
    {
        public DevHubIacTemplateProperties() { }
        public string InstanceName { get { throw null; } set { } }
        public string InstanceStage { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType? QuickStartTemplateType { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateDetails> TemplateDetails { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubIacTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubManifestGenerationMode : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubManifestGenerationMode(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode left, Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode left, Azure.ResourceManager.DevHub.Models.DevHubManifestGenerationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubManifestType : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubManifestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubManifestType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubManifestType Helm { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubManifestType Kube { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubManifestType Kustomize { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubManifestType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubManifestType left, Azure.ResourceManager.DevHub.Models.DevHubManifestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubManifestType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubManifestType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubManifestType left, Azure.ResourceManager.DevHub.Models.DevHubManifestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevHubOidcCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials>
    {
        public DevHubOidcCredentials() { }
        public string AzureClientId { get { throw null; } set { } }
        public string AzureTenantId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubOperationDisplay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay>
    {
        internal DevHubOperationDisplay() { }
        public string Description { get { throw null; } }
        public string Operation { get { throw null; } }
        public string Provider { get { throw null; } }
        public string Resource { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationDisplay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubOperationListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>
    {
        internal DevHubOperationListResult() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DevHub.Models.DeveloperHubOperationInfo> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubOperationListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubOperationListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubOperationListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubOperationListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubOperationListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubOperationOrigin : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubOperationOrigin(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin System { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin User { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin UserSystem { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin left, Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin left, Azure.ResourceManager.DevHub.Models.DevHubOperationOrigin right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubPullRequestStatus : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubPullRequestStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus Merged { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus Removed { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus Submitted { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus left, Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus left, Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubQuickStartTemplateType : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubQuickStartTemplateType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType HCI { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType HciAks { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType HciArcVm { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType left, Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType left, Azure.ResourceManager.DevHub.Models.DevHubQuickStartTemplateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubRepositoryProviderType : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubRepositoryProviderType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType Ado { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType GitHub { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType left, Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType left, Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevHubScaleProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty>
    {
        public DevHubScaleProperty() { }
        public int? NumberOfStores { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string Stage { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubScaleProperty JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubScaleProperty PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubScaleProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubScaleProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubScaleProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubStageInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubStageInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubStageInfo>
    {
        public DevHubStageInfo() { }
        public System.Collections.Generic.IList<string> Dependencies { get { throw null; } }
        public string GitEnvironment { get { throw null; } set { } }
        public string StageName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubStageInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubStageInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubStageInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubStageInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubStageInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubStageInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubStageInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubStageInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubStageInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubTagsPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTagsPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTagsPatch>
    {
        public DevHubTagsPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTagsPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTagsPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubTagsPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTagsPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTagsPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubTagsPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTagsPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTagsPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTagsPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubTemplateParameterDefault : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault>
    {
        internal DevHubTemplateParameterDefault() { }
        public string ReferenceParameter { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterDefault>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubTemplateParameterKind : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubTemplateParameterKind(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind AzureContainerRegistry { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind AzureKeyvaultUri { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind AzureManagedCluster { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind AzureResourceGroup { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind AzureServiceConnection { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ClusterResourceType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ContainerImageName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ContainerImageVersion { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind DirPath { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind DockerFileName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind EnvVarMap { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind FilePath { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind Flag { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind HelmChartOverrides { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ImagePullPolicy { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind IngressHostName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesNamespace { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesProbeDelay { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesProbeHttpPath { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesProbePeriod { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesProbeThreshold { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesProbeTimeout { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesProbeType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesResourceLimit { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesResourceName { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind KubernetesResourceRequest { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind Label { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind Port { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ReplicaCount { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind RepositoryBranch { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ResourceLimit { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ScalingResourceType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind ScalingResourceUtilization { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind WorkflowAuthType { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind WorkflowName { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind left, Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind left, Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubTemplateParameterType : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubTemplateParameterType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType Float { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType Int { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType left, Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType left, Azure.ResourceManager.DevHub.Models.DevHubTemplateParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevHubTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties>
    {
        internal DevHubTemplateProperties() { }
        public string DefaultVersion { get { throw null; } }
        public string Description { get { throw null; } }
        public string TemplateName { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateType? TemplateType { get { throw null; } }
        public System.Collections.Generic.IList<string> Versions { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubTemplateReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference>
    {
        public DevHubTemplateReference() { }
        public string Destination { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Parameters { get { throw null; } }
        public Azure.Core.ResourceIdentifier TemplateId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubTemplateType : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubTemplateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubTemplateType(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateType Deployment { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateType Dockerfile { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateType Manifest { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubTemplateType Workflow { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubTemplateType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubTemplateType left, Azure.ResourceManager.DevHub.Models.DevHubTemplateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubTemplateType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubTemplateType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubTemplateType left, Azure.ResourceManager.DevHub.Models.DevHubTemplateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DevHubTemplateWorkflowProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile>
    {
        public DevHubTemplateWorkflowProfile() { }
        public Azure.ResourceManager.DevHub.Models.AdoProviderProfile AdoProviderProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? AuthStatus { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateReference DeploymentTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateReference DockerfileTemplate { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GitHubProviderProfile GitHubProviderProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.DevHubTemplateReference> ManifestTemplates { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DeveloperHubPullRequestContent PullRequest { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubRepositoryProviderType? RepositoryProvider { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateReference WorkflowTemplate { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubVersionedTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties>
    {
        internal DevHubVersionedTemplateProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DevHub.Models.DeveloperHubParameterContent> Parameters { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateType? TemplateType { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubVersionedTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubWorkflowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties>
    {
        public DevHubWorkflowProperties() { }
        public Azure.ResourceManager.DevHub.Models.DevHubArtifactGenerationProperties ArtifactGenerationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.AzurePipelineProfile AzurePipelineProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfile GithubWorkflowProfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubTemplateWorkflowProfile TemplateWorkflowProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DevHubWorkflowRun : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun>
    {
        public DevHubWorkflowRun() { }
        public bool? IsSucceeded { get { throw null; } }
        public System.DateTimeOffset? LastRunOn { get { throw null; } }
        public Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus? WorkflowRunStatus { get { throw null; } }
        public string WorkflowRunUri { get { throw null; } }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DevHubWorkflowRunStatus : System.IEquatable<Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DevHubWorkflowRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus Queued { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus left, Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus left, Azure.ResourceManager.DevHub.Models.DevHubWorkflowRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GitHubProviderProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DevHub.Models.GitHubProviderProfile>
    {
        public GitHubProviderProfile() { }
        public Azure.ResourceManager.DevHub.Models.DevHubOidcCredentials OidcCredentials { get { throw null; } set { } }
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
        public Azure.ResourceManager.DevHub.Models.DevHubContainerRegistryInfo Acr { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AksResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubAuthorizationStatus? AuthStatus { get { throw null; } }
        public string BranchName { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubDeploymentProperties DeploymentProperties { get { throw null; } set { } }
        public string DockerBuildContext { get { throw null; } set { } }
        public string Dockerfile { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubWorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.GitHubWorkflowProfileOidcCredentials OidcCredentials { get { throw null; } set { } }
        public Azure.ResourceManager.DevHub.Models.DevHubPullRequestStatus? PrStatus { get { throw null; } }
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
}
