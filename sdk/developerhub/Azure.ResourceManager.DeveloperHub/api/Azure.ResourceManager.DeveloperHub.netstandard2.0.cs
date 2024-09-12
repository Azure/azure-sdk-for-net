namespace Azure.ResourceManager.DeveloperHub
{
    public static partial class DeveloperHubExtensions
    {
        public static Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>> GeneratePreviewArtifacts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>>> GeneratePreviewArtifactsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> GetGitHubOAuthResponse(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>> GetGitHubOAuthResponseAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource GetGitHubOAuthResponseResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseCollection GetGitHubOAuthResponses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetIacProfile(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> GetIacProfileAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.IacProfileResource GetIacProfileResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.IacProfileCollection GetIacProfiles(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetIacProfiles(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetIacProfilesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetWorkflow(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> GetWorkflowAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.WorkflowResource GetWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.WorkflowCollection GetWorkflows(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetWorkflows(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetWorkflowsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GitHubOAuthResponseCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>, System.Collections.IEnumerable
    {
        protected GitHubOAuthResponseCollection() { }
        public virtual Azure.Response<bool> Exists(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> Get(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>> GetAsync(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> GetIfExists(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>> GetIfExistsAsync(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GitHubOAuthResponseData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>
    {
        public GitHubOAuthResponseData() { }
        public string Username { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubOAuthResponseResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GitHubOAuthResponseResource() { }
        public virtual Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> Get(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>> GetAsync(string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult> GitHubOAuth(Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>> GitHubOAuthAsync(Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacProfileCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeveloperHub.IacProfileResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.IacProfileResource>, System.Collections.IEnumerable
    {
        protected IacProfileCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeveloperHub.IacProfileResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string iacProfileName, Azure.ResourceManager.DeveloperHub.IacProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeveloperHub.IacProfileResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string iacProfileName, Azure.ResourceManager.DeveloperHub.IacProfileData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> Get(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> GetAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetIfExists(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeveloperHub.IacProfileResource>> GetIfExistsAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeveloperHub.IacProfileResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeveloperHub.IacProfileResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeveloperHub.IacProfileResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.IacProfileResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class IacProfileData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.IacProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>
    {
        public IacProfileData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus? AuthStatus { get { throw null; } }
        public string BranchName { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus? PrStatus { get { throw null; } }
        public int? PullNumber { get { throw null; } }
        public string RepositoryMainBranch { get { throw null; } set { } }
        public string RepositoryName { get { throw null; } set { } }
        public string RepositoryOwner { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeveloperHub.Models.StageProperties> Stages { get { throw null; } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageAccountResourceGroup { get { throw null; } set { } }
        public string StorageAccountSubscription { get { throw null; } set { } }
        public string StorageContainerName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties> Templates { get { throw null; } }
        Azure.ResourceManager.DeveloperHub.IacProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.IacProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacProfileResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.IacProfileData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected IacProfileResource() { }
        public virtual Azure.ResourceManager.DeveloperHub.IacProfileData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string iacProfileName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult> Export(Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>> ExportAsync(Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult> Scale(Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>> ScaleAsync(Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Sync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SyncAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeveloperHub.IacProfileData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.IacProfileData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.IacProfileData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> Update(Azure.ResourceManager.DeveloperHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> UpdateAsync(Azure.ResourceManager.DeveloperHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class WorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeveloperHub.WorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.WorkflowResource>, System.Collections.IEnumerable
    {
        protected WorkflowCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeveloperHub.WorkflowResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.DeveloperHub.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeveloperHub.WorkflowResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workflowName, Azure.ResourceManager.DeveloperHub.WorkflowData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> Get(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetAll(string managedClusterResource = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetAllAsync(string managedClusterResource = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> GetAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetIfExists(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeveloperHub.WorkflowResource>> GetIfExistsAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeveloperHub.WorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeveloperHub.WorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeveloperHub.WorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.WorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class WorkflowData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.WorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>
    {
        public WorkflowData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DeveloperHub.Models.ACR Acr { get { throw null; } set { } }
        public string AksResourceId { get { throw null; } set { } }
        public string AppName { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus? AuthStatus { get { throw null; } }
        public string BranchName { get { throw null; } set { } }
        public string BuilderVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties DeploymentProperties { get { throw null; } set { } }
        public string DockerBuildContext { get { throw null; } set { } }
        public string Dockerfile { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode? DockerfileGenerationMode { get { throw null; } set { } }
        public string DockerfileOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage? GenerationLanguage { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public string ImageTag { get { throw null; } set { } }
        public string LanguageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.WorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode? ManifestGenerationMode { get { throw null; } set { } }
        public string ManifestOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType? ManifestType { get { throw null; } set { } }
        public string NamespacePropertiesArtifactGenerationPropertiesNamespace { get { throw null; } set { } }
        public string NamespacePropertiesGithubWorkflowProfileNamespace { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials OidcCredentials { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus? PrStatus { get { throw null; } }
        public string PrURL { get { throw null; } }
        public int? PullNumber { get { throw null; } }
        public string RepositoryName { get { throw null; } set { } }
        public string RepositoryOwner { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.WorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.WorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.WorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected WorkflowResource() { }
        public virtual Azure.ResourceManager.DeveloperHub.WorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workflowName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult> Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeveloperHub.WorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.WorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.WorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> Update(Azure.ResourceManager.DeveloperHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> UpdateAsync(Azure.ResourceManager.DeveloperHub.Models.TagsObject tagsObject, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeveloperHub.Mocking
{
    public partial class MockableDeveloperHubArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeveloperHubArmClient() { }
        public virtual Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource GetGitHubOAuthResponseResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeveloperHub.IacProfileResource GetIacProfileResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeveloperHub.WorkflowResource GetWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDeveloperHubResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeveloperHubResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetIacProfile(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.IacProfileResource>> GetIacProfileAsync(string iacProfileName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeveloperHub.IacProfileCollection GetIacProfiles() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetWorkflow(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.WorkflowResource>> GetWorkflowAsync(string workflowName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeveloperHub.WorkflowCollection GetWorkflows() { throw null; }
    }
    public partial class MockableDeveloperHubSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeveloperHubSubscriptionResource() { }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>> GeneratePreviewArtifacts(Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyDictionary<string, string>>> GeneratePreviewArtifactsAsync(Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties artifactGenerationProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource> GetGitHubOAuthResponse(Azure.Core.AzureLocation location, string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseResource>> GetGitHubOAuthResponseAsync(Azure.Core.AzureLocation location, string code, string state, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseCollection GetGitHubOAuthResponses(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetIacProfiles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeveloperHub.IacProfileResource> GetIacProfilesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetWorkflows(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeveloperHub.WorkflowResource> GetWorkflowsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeveloperHub.Models
{
    public partial class ACR : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ACR>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ACR>
    {
        public ACR() { }
        public string AcrRegistryName { get { throw null; } set { } }
        public string AcrRepositoryName { get { throw null; } set { } }
        public string AcrResourceGroup { get { throw null; } set { } }
        public string AcrSubscriptionId { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.ACR System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ACR>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ACR>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.ACR System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ACR>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ACR>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ACR>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDeveloperHubModelFactory
    {
        public static Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult DeleteWorkflowResult(string status = null) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult GitHubOAuthInfoResult(string authURL = null, string token = null) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.GitHubOAuthResponseData GitHubOAuthResponseData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string username = null) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.IacProfileData IacProfileData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.Models.StageProperties> stages = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties> templates = null, string storageAccountSubscription = null, string storageAccountResourceGroup = null, string storageAccountName = null, string storageContainerName = null, string repositoryName = null, string repositoryMainBranch = null, string repositoryOwner = null, Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus? authStatus = default(Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus?), int? pullNumber = default(int?), Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus? prStatus = default(Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus?), string branchName = null) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.PrLinkResult PrLinkResult(string prLink = null) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.WorkflowData WorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage? generationLanguage = default(Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage?), string languageVersion = null, string builderVersion = null, string port = null, string appName = null, string dockerfileOutputDirectory = null, string manifestOutputDirectory = null, Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode? dockerfileGenerationMode = default(Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode?), Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode? manifestGenerationMode = default(Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode?), Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType? manifestType = default(Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType?), string imageName = null, string namespacePropertiesArtifactGenerationPropertiesNamespace = null, string imageTag = null, string repositoryOwner = null, string repositoryName = null, string branchName = null, string dockerfile = null, string dockerBuildContext = null, Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties deploymentProperties = null, string namespacePropertiesGithubWorkflowProfileNamespace = null, Azure.ResourceManager.DeveloperHub.Models.ACR acr = null, Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials oidcCredentials = null, string aksResourceId = null, string prURL = null, int? pullNumber = default(int?), Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus? prStatus = default(Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus?), Azure.ResourceManager.DeveloperHub.Models.WorkflowRun lastWorkflowRun = null, Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus? authStatus = default(Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus?)) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.WorkflowRun WorkflowRun(bool? succeeded = default(bool?), string workflowRunURL = null, System.DateTimeOffset? lastRunOn = default(System.DateTimeOffset?), Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus? workflowRunStatus = default(Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus?)) { throw null; }
    }
    public partial class ArtifactGenerationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties>
    {
        public ArtifactGenerationProperties() { }
        public string AppName { get { throw null; } set { } }
        public string BuilderVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode? DockerfileGenerationMode { get { throw null; } set { } }
        public string DockerfileOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage? GenerationLanguage { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public string ImageTag { get { throw null; } set { } }
        public string LanguageVersion { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode? ManifestGenerationMode { get { throw null; } set { } }
        public string ManifestOutputDirectory { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType? ManifestType { get { throw null; } set { } }
        public string Namespace { get { throw null; } set { } }
        public string Port { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ArtifactGenerationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthorizationStatus : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthorizationStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus Authorized { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus Error { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus NotFound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus left, Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus left, Azure.ResourceManager.DeveloperHub.Models.AuthorizationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeleteWorkflowResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>
    {
        internal DeleteWorkflowResult() { }
        public string Status { get { throw null; } }
        Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeleteWorkflowResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties>
    {
        public DeploymentProperties() { }
        public string HelmChartPath { get { throw null; } set { } }
        public string HelmValues { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> KubeManifestLocations { get { throw null; } }
        public Azure.ResourceManager.DeveloperHub.Models.ManifestType? ManifestType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Overrides { get { throw null; } }
        Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.DeploymentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DockerfileGenerationMode : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DockerfileGenerationMode(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode left, Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode left, Azure.ResourceManager.DeveloperHub.Models.DockerfileGenerationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExportTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent>
    {
        public ExportTemplateContent() { }
        public string InstanceName { get { throw null; } set { } }
        public string InstanceStage { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGroupIds { get { throw null; } }
        public string SiteId { get { throw null; } set { } }
        public string TemplateName { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ExportTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerationLanguage : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerationLanguage(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Clojure { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Csharp { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Erlang { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Go { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Gomodule { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Gradle { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Java { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Javascript { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Php { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Python { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Ruby { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Rust { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage Swift { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage left, Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage left, Azure.ResourceManager.DeveloperHub.Models.GenerationLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenerationManifestType : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenerationManifestType(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType Helm { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType Kube { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType left, Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType left, Azure.ResourceManager.DeveloperHub.Models.GenerationManifestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GitHubOAuthCallContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent>
    {
        public GitHubOAuthCallContent() { }
        public System.Uri RedirectUri { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthCallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubOAuthInfoResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>
    {
        internal GitHubOAuthInfoResult() { }
        public string AuthURL { get { throw null; } }
        public string Token { get { throw null; } }
        Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubOAuthInfoResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubWorkflowProfileOidcCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials>
    {
        public GitHubWorkflowProfileOidcCredentials() { }
        public string AzureClientId { get { throw null; } set { } }
        public string AzureTenantId { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.GitHubWorkflowProfileOidcCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacTemplateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails>
    {
        public IacTemplateDetails() { }
        public int? Count { get { throw null; } set { } }
        public string NamingConvention { get { throw null; } set { } }
        public string ProductName { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IacTemplateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties>
    {
        public IacTemplateProperties() { }
        public string InstanceName { get { throw null; } set { } }
        public string InstanceStage { get { throw null; } set { } }
        public Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType? QuickStartTemplateType { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeveloperHub.Models.IacTemplateDetails> TemplateDetails { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.IacTemplateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManifestGenerationMode : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManifestGenerationMode(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode left, Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode left, Azure.ResourceManager.DeveloperHub.Models.ManifestGenerationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManifestType : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.ManifestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManifestType(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.ManifestType Helm { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.ManifestType Kube { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.ManifestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.ManifestType left, Azure.ResourceManager.DeveloperHub.Models.ManifestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.ManifestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.ManifestType left, Azure.ResourceManager.DeveloperHub.Models.ManifestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrLinkResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>
    {
        internal PrLinkResult() { }
        public string PrLink { get { throw null; } }
        Azure.ResourceManager.DeveloperHub.Models.PrLinkResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.PrLinkResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.PrLinkResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PullRequestStatus : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PullRequestStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus Merged { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus Removed { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus Submitted { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus left, Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus left, Azure.ResourceManager.DeveloperHub.Models.PullRequestStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct QuickStartTemplateType : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public QuickStartTemplateType(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType ALL { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType HCI { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType Hciaks { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType Hciarcvm { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType left, Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType left, Azure.ResourceManager.DeveloperHub.Models.QuickStartTemplateType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ScaleProperty : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty>
    {
        public ScaleProperty() { }
        public int? NumberOfStores { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string Stage { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.ScaleProperty System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.ScaleProperty System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScaleTemplateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent>
    {
        public ScaleTemplateContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeveloperHub.Models.ScaleProperty> ScaleProperties { get { throw null; } }
        public string TemplateName { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.ScaleTemplateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.StageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.StageProperties>
    {
        public StageProperties() { }
        public System.Collections.Generic.IList<string> Dependencies { get { throw null; } }
        public string GitEnvironment { get { throw null; } set { } }
        public string StageName { get { throw null; } set { } }
        Azure.ResourceManager.DeveloperHub.Models.StageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.StageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.StageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.StageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.StageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.StageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.StageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TagsObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.TagsObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.TagsObject>
    {
        public TagsObject() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.DeveloperHub.Models.TagsObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.TagsObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.TagsObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.TagsObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.TagsObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.TagsObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.TagsObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowRun : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.WorkflowRun>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.WorkflowRun>
    {
        public WorkflowRun() { }
        public System.DateTimeOffset? LastRunOn { get { throw null; } }
        public bool? Succeeded { get { throw null; } }
        public Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus? WorkflowRunStatus { get { throw null; } set { } }
        public string WorkflowRunURL { get { throw null; } }
        Azure.ResourceManager.DeveloperHub.Models.WorkflowRun System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.WorkflowRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeveloperHub.Models.WorkflowRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeveloperHub.Models.WorkflowRun System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.WorkflowRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.WorkflowRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeveloperHub.Models.WorkflowRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowRunStatus : System.IEquatable<Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowRunStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus Completed { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus Inprogress { get { throw null; } }
        public static Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus Queued { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus left, Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus left, Azure.ResourceManager.DeveloperHub.Models.WorkflowRunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
