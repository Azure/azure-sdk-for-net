namespace Azure.ResourceManager.KoreAIArtemis
{
    public partial class AzureResourceManagerKoreAIArtemisContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerKoreAIArtemisContext() { }
        public static Azure.ResourceManager.KoreAIArtemis.AzureResourceManagerKoreAIArtemisContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class KoreAIArtemisExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult> ActivateResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>> ActivateResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetKoreAIArtemisOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> GetKoreAIArtemisOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource GetKoreAIArtemisOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationCollection GetKoreAIArtemisOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetKoreAIArtemisOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetKoreAIArtemisOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource GetKoreAIArtemisWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class KoreAIArtemisOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>, System.Collections.IEnumerable
    {
        protected KoreAIArtemisOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KoreAIArtemisOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>
    {
        public KoreAIArtemisOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KoreAIArtemisOrganizationResource() { }
        public virtual Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> GetKoreAIArtemisWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>> GetKoreAIArtemisWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceCollection GetKoreAIArtemisWorkspaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult> GetWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>> GetWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KoreAIArtemisWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>, System.Collections.IEnumerable
    {
        protected KoreAIArtemisWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class KoreAIArtemisWorkspaceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>
    {
        public KoreAIArtemisWorkspaceData() { }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected KoreAIArtemisWorkspaceResource() { }
        public virtual Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail> GetDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>> GetDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult> GetLinkedSaaS(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>> GetLinkedSaaSAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation LinkSaaS(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> LinkSaaSAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.KoreAIArtemis.Mocking
{
    public partial class MockableKoreAIArtemisArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableKoreAIArtemisArmClient() { }
        public virtual Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource GetKoreAIArtemisOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceResource GetKoreAIArtemisWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableKoreAIArtemisResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKoreAIArtemisResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetKoreAIArtemisOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource>> GetKoreAIArtemisOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationCollection GetKoreAIArtemisOrganizations() { throw null; }
    }
    public partial class MockableKoreAIArtemisSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableKoreAIArtemisSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult> ActivateResource(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>> ActivateResourceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetKoreAIArtemisOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationResource> GetKoreAIArtemisOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.KoreAIArtemis.Models
{
    public partial class ActivateSaasContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent>
    {
        public ActivateSaasContent(string saasGuid, string publisherId) { }
        public string PublisherId { get { throw null; } }
        public string SaasGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmKoreAIArtemisModelFactory
    {
        public static Azure.ResourceManager.KoreAIArtemis.Models.ActivateSaasContent ActivateSaasContent(string saasGuid = null, string publisherId = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace DiscoveredWorkspace(string partnerResourceId = null, string name = null, string ownerEmail = null, bool? isDefault = default(bool?), Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus? status = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus?), Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct? product = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> marketplaceDetails = null, bool isManagedByLiftr = false, Azure.Core.ResourceIdentifier armResourceId = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails KoreAIArtemisCompanyDetails(string companyName = null, string officeAddress = null, string country = null, string domain = null, string businessType = null, int? numberOfEmployees = default(int?)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties KoreAIArtemisDefaultWorkspaceProperties(string name = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct? product = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> marketplaceDetails = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails KoreAIArtemisMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus?), string saasResourceId = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails KoreAIArtemisOfferDetails(string publisherId = null, string offerId = null, string planId = null, string planName = null, string termUnit = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisOrganizationData KoreAIArtemisOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties KoreAIArtemisOrganizationPartnerProperties(string organizationName = null, string billingEmail = null, string ownerEmail = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties defaultWorkspace = null, string partnerResourceId = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch KoreAIArtemisOrganizationPartnerPropertiesPatch(string organizationName = null, string billingEmail = null, string ownerEmail = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch KoreAIArtemisOrganizationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch properties = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties KoreAIArtemisOrganizationProperties(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties partnerProperties = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails user = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails companyDetails = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties singleSignOn = null, string defaultWorkspaceId = null, int? workspaceCount = default(int?), Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState? provisioningState = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch KoreAIArtemisOrganizationPropertiesPatch(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch partnerProperties = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails user = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails companyDetails = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties KoreAIArtemisSingleSignOnProperties(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType type = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType), Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState? state = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState?), string enterpriseAppId = null, string uri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails KoreAIArtemisUserDetails(string firstName = null, string lastName = null, string emailAddress = null, string upn = null, string phoneNumber = null, string alternateEmail = null, string address = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.KoreAIArtemisWorkspaceData KoreAIArtemisWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties KoreAIArtemisWorkspacePartnerProperties(string name = null, string ownerEmail = null, string partnerResourceId = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties KoreAIArtemisWorkspaceProperties(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct? product = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> marketplaceDetails = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties partnerProperties = null, bool? isDefault = default(bool?), Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus? status = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus?), Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState? provisioningState = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult ListWorkspacesResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace> value = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult SaaSResourceDetailsResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? saasId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail WorkspaceDetail(string id = null, Azure.Core.ResourceIdentifier azureResourceId = null, string organizationId = null, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties partnerProperties = null, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus status = default(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus), System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject> projects = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties WorkspaceDetailPartnerProperties(string name = null, string ownerEmail = null, int retentionDays = 0, bool isDefault = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails> marketplaceDetails = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem WorkspaceLinkedSaaSItem(Azure.Core.ResourceIdentifier saaSResourceId = null, bool? isHiddenSaaS = default(bool?)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult WorkspaceLinkedSaaSListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem> value = null) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails WorkspaceMarketplaceDetails(Azure.Core.ResourceIdentifier resourceId = null, string mpId = null, string planId = null, string planName = null, string offerId = null, string publisherId = null, string termId = null, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus? status = default(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus?)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject WorkspaceProject(string id = null, string name = null, string description = null, string createdBy = null, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus status = default(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus), int agentCount = 0, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset updatedOn = default(System.DateTimeOffset)) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent WorkspaceSaasContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> saaSResourceIds = null) { throw null; }
    }
    public partial class DiscoveredWorkspace : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace>
    {
        internal DiscoveredWorkspace() { }
        public Azure.Core.ResourceIdentifier ArmResourceId { get { throw null; } }
        public bool? IsDefault { get { throw null; } }
        public bool IsManagedByLiftr { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> MarketplaceDetails { get { throw null; } }
        public string Name { get { throw null; } }
        public string OwnerEmail { get { throw null; } }
        public string PartnerResourceId { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct? Product { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails>
    {
        public KoreAIArtemisCompanyDetails() { }
        public string BusinessType { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public int? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisDefaultWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties>
    {
        public KoreAIArtemisDefaultWorkspaceProperties(string name, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> marketplaceDetails) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> MarketplaceDetails { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct? Product { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails>
    {
        public KoreAIArtemisMarketplaceDetails(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails offerDetails) { }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails OfferDetails { get { throw null; } set { } }
        public string SaasResourceId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KoreAIArtemisMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KoreAIArtemisMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KoreAIArtemisOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails>
    {
        public KoreAIArtemisOfferDetails(string publisherId, string offerId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisOrganizationPartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties>
    {
        public KoreAIArtemisOrganizationPartnerProperties(string organizationName, string billingEmail, string ownerEmail, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties defaultWorkspace) { }
        public string BillingEmail { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisDefaultWorkspaceProperties DefaultWorkspace { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public string OwnerEmail { get { throw null; } set { } }
        public string PartnerResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisOrganizationPartnerPropertiesPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch>
    {
        public KoreAIArtemisOrganizationPartnerPropertiesPatch() { }
        public string BillingEmail { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public string OwnerEmail { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch>
    {
        public KoreAIArtemisOrganizationPatch() { }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties>
    {
        public KoreAIArtemisOrganizationProperties(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties partnerProperties, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails user) { }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails CompanyDetails { get { throw null; } set { } }
        public string DefaultWorkspaceId { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerProperties PartnerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties SingleSignOn { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails User { get { throw null; } set { } }
        public int? WorkspaceCount { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KoreAIArtemisOrganizationPropertiesPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch>
    {
        public KoreAIArtemisOrganizationPropertiesPatch() { }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisCompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPartnerPropertiesPatch PartnerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisOrganizationPropertiesPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KoreAIArtemisResourceProvisioningState : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KoreAIArtemisResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KoreAIArtemisSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties>
    {
        internal KoreAIArtemisSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState? State { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType Type { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KoreAIArtemisSingleSignOnState : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KoreAIArtemisSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KoreAIArtemisSingleSignOnType : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KoreAIArtemisSingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisSingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KoreAIArtemisUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails>
    {
        public KoreAIArtemisUserDetails() { }
        public string Address { get { throw null; } set { } }
        public string AlternateEmail { get { throw null; } set { } }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KoreAIArtemisWorkspaceLifecycleStatus : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KoreAIArtemisWorkspaceLifecycleStatus(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus Active { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus Archived { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus Suspended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KoreAIArtemisWorkspacePartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties>
    {
        public KoreAIArtemisWorkspacePartnerProperties(string name) { }
        public string Name { get { throw null; } set { } }
        public string OwnerEmail { get { throw null; } set { } }
        public string PartnerResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KoreAIArtemisWorkspaceProduct : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KoreAIArtemisWorkspaceProduct(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct Aiforservice { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct Aiforwork { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct left, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KoreAIArtemisWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties>
    {
        public KoreAIArtemisWorkspaceProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> marketplaceDetails, Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties partnerProperties) { }
        public bool? IsDefault { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisMarketplaceDetails> MarketplaceDetails { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspacePartnerProperties PartnerProperties { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProduct? Product { get { throw null; } set { } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus? Status { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListWorkspacesResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>
    {
        internal ListWorkspacesResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KoreAIArtemis.Models.DiscoveredWorkspace> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.ListWorkspacesResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaaSResourceDetailsResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>
    {
        internal SaaSResourceDetailsResult() { }
        public System.Guid? SaasId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.SaaSResourceDetailsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>
    {
        internal WorkspaceDetail() { }
        public Azure.Core.ResourceIdentifier AzureResourceId { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string OrganizationId { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties PartnerProperties { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject> Projects { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.KoreAIArtemisWorkspaceLifecycleStatus Status { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceDetailPartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties>
    {
        internal WorkspaceDetailPartnerProperties() { }
        public bool IsDefault { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails> MarketplaceDetails { get { throw null; } }
        public string Name { get { throw null; } }
        public string OwnerEmail { get { throw null; } }
        public int RetentionDays { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceDetailPartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceLinkedSaaSItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem>
    {
        internal WorkspaceLinkedSaaSItem() { }
        public bool? IsHiddenSaaS { get { throw null; } }
        public Azure.Core.ResourceIdentifier SaaSResourceId { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceLinkedSaaSListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>
    {
        internal WorkspaceLinkedSaaSListResult() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSItem> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceLinkedSaaSListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails>
    {
        internal WorkspaceMarketplaceDetails() { }
        public string MpId { get { throw null; } }
        public string OfferId { get { throw null; } }
        public string PlanId { get { throw null; } }
        public string PlanName { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus? Status { get { throw null; } }
        public string TermId { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceMarketplaceStatus : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceMarketplaceStatus(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus left, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus left, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceMarketplaceStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceProject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject>
    {
        internal WorkspaceProject() { }
        public int AgentCount { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus Status { get { throw null; } }
        public System.DateTimeOffset UpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkspaceProjectStatus : System.IEquatable<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkspaceProjectStatus(string value) { throw null; }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus Active { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus Archived { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus Deployed { get { throw null; } }
        public static Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus InDevelopment { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus left, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus left, Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceProjectStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceSaasContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent>
    {
        public WorkspaceSaasContent(System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> saaSResourceIds) { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SaaSResourceIds { get { throw null; } }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.KoreAIArtemis.Models.WorkspaceSaasContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
