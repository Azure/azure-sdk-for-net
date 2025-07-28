namespace Azure.ResourceManager.NeonPostgres
{
    public partial class AzureResourceManagerNeonPostgresContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNeonPostgresContext() { }
        public static Azure.ResourceManager.NeonPostgres.AzureResourceManagerNeonPostgresContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class NeonBranchCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonBranchResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonBranchResource>, System.Collections.IEnumerable
    {
        protected NeonBranchCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonBranchResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string branchName, Azure.ResourceManager.NeonPostgres.NeonBranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonBranchResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string branchName, Azure.ResourceManager.NeonPostgres.NeonBranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonBranchResource> Get(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonBranchResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonBranchResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonBranchResource>> GetAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonBranchResource> GetIfExists(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonBranchResource>> GetIfExistsAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.NeonBranchResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonBranchResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.NeonBranchResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonBranchResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeonBranchData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>
    {
        public NeonBranchData() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonBranchData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonBranchData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonBranchResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeonBranchResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonBranchData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName, string branchName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonBranchResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonBranchResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.Models.NeonCompute> GetComputes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.Models.NeonCompute> GetComputesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint> GetEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint> GetEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase> GetNeonDatabases(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase> GetNeonDatabasesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.Models.NeonRole> GetNeonRoles(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.Models.NeonRole> GetNeonRolesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.NeonBranchData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonBranchData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonBranchData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonBranchResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonBranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonBranchResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonBranchData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeonOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>, System.Collections.IEnumerable
    {
        protected NeonOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeonOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>
    {
        public NeonOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeonOrganizationResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonProjectResource> GetNeonProject(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonProjectResource>> GetNeonProjectAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonProjectCollection GetNeonProjects() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NeonPostgresExtensions
    {
        public static Azure.ResourceManager.NeonPostgres.NeonBranchResource GetNeonBranchResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetNeonOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationResource GetNeonOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationCollection GetNeonOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonProjectResource GetNeonProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult> GetPostgresVersionsOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>> GetPostgresVersionsOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NeonProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonProjectResource>, System.Collections.IEnumerable
    {
        protected NeonProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.NeonPostgres.NeonProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string projectName, Azure.ResourceManager.NeonPostgres.NeonProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonProjectResource> Get(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonProjectResource>> GetAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonProjectResource> GetIfExists(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NeonPostgres.NeonProjectResource>> GetIfExistsAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NeonPostgres.NeonProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NeonPostgres.NeonProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NeonPostgres.NeonProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.NeonProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NeonProjectData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>
    {
        public NeonProjectData() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonProjectResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NeonProjectResource() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName, string projectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties> GetConnectionUri(Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties connectionUriParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>> GetConnectionUriAsync(Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties connectionUriParameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonBranchResource> GetNeonBranch(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonBranchResource>> GetNeonBranchAsync(string branchName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonBranchCollection GetNeonBranches() { throw null; }
        Azure.ResourceManager.NeonPostgres.NeonProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.NeonProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.NeonProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NeonPostgres.NeonProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NeonPostgres.NeonProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Mocking
{
    public partial class MockableNeonPostgresArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresArmClient() { }
        public virtual Azure.ResourceManager.NeonPostgres.NeonBranchResource GetNeonBranchResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationResource GetNeonOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonProjectResource GetNeonProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNeonPostgresResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource>> GetNeonOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NeonPostgres.NeonOrganizationCollection GetNeonOrganizations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult> GetPostgresVersionsOrganization(Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>> GetPostgresVersionsOrganizationAsync(Azure.ResourceManager.NeonPostgres.Models.PgVersion pgVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableNeonPostgresSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNeonPostgresSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NeonPostgres.NeonOrganizationResource> GetNeonOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NeonPostgres.Models
{
    public static partial class ArmNeonPostgresModelFactory
    {
        public static Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties ConnectionUriProperties(string projectId = null, string branchId = null, string databaseName = null, string roleName = null, string endpointId = null, bool? isPooled = default(bool?), string connectionStringUri = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonBranchData NeonBranchData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties NeonBranchProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string projectId = null, string parentId = null, string roleName = null, string databaseName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> roles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> databases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties> endpoints = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonCompute NeonCompute(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties NeonComputeProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string region = null, int? cpuCores = default(int?), int? memory = default(int?), string status = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonDatabase NeonDatabase(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties NeonDatabaseProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string branchId = null, string ownerName = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint NeonEndpoint(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties NeonEndpointProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string projectId = null, string branchId = null, Azure.ResourceManager.NeonPostgres.Models.EndpointType? endpointType = default(Azure.ResourceManager.NeonPostgres.Models.EndpointType?)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonOrganizationData NeonOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties NeonOrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails marketplaceDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails userDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails companyDetails = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties partnerOrganizationProperties = null, Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties projectProperties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.NeonProjectData NeonProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties NeonProjectProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attribute = null, string regionId = null, long? storage = default(long?), int? postgresVersion = default(int?), int? historyRetention = default(int?), Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings defaultEndpointSettings = null, Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties branch = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> roles = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> databases = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties> endpoints = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonRole NeonRole(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties properties = null) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties NeonRoleProperties(string entityId = null, string entityName = null, string createdAt = null, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? provisioningState = default(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.Attributes> attributes = null, string branchId = null, System.Collections.Generic.IEnumerable<string> permissions = null, bool? isSuperUser = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult PgVersionsResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NeonPostgres.Models.PgVersion> versions = null) { throw null; }
    }
    public partial class Attributes : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>
    {
        public Attributes(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.Attributes System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.Attributes System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.Attributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionUriProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>
    {
        public ConnectionUriProperties() { }
        public string BranchId { get { throw null; } set { } }
        public string ConnectionStringUri { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
        public string EndpointId { get { throw null; } set { } }
        public bool? IsPooled { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public string RoleName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.ConnectionUriProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DefaultEndpointSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>
    {
        public DefaultEndpointSettings(float autoscalingLimitMinCu, float autoscalingLimitMaxCu) { }
        public float AutoscalingLimitMaxCu { get { throw null; } set { } }
        public float AutoscalingLimitMinCu { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EndpointType : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.EndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EndpointType(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.EndpointType ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.EndpointType ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.EndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.EndpointType left, Azure.ResourceManager.NeonPostgres.Models.EndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.EndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.EndpointType left, Azure.ResourceManager.NeonPostgres.Models.EndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonBranchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties>
    {
        public NeonBranchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string CreatedAt { get { throw null; } }
        public string DatabaseName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> Databases { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties> Endpoints { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public string ParentId { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string RoleName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> Roles { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonCompanyDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>
    {
        public NeonCompanyDetails() { }
        public string BusinessPhone { get { throw null; } set { } }
        public string CompanyName { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public long? NumberOfEmployees { get { throw null; } set { } }
        public string OfficeAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonCompute : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompute>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompute>
    {
        internal NeonCompute() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompute System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompute>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompute>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonCompute System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompute>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompute>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonCompute>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonComputeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties>
    {
        internal NeonComputeProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public int? CpuCores { get { throw null; } }
        public string CreatedAt { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } }
        public int? Memory { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string Region { get { throw null; } }
        public string Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonComputeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonDatabase : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase>
    {
        internal NeonDatabase() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonDatabase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonDatabase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonDatabaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>
    {
        public NeonDatabaseProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string BranchId { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public string OwnerName { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonEndpoint : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint>
    {
        internal NeonEndpoint() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonEndpointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties>
    {
        public NeonEndpointProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string BranchId { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.EndpointType? EndpointType { get { throw null; } set { } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>
    {
        public NeonMarketplaceDetails(Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails offerDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>
    {
        public NeonOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>
    {
        public NeonOrganizationProperties(Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails marketplaceDetails, Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails userDetails, Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails companyDetails) { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonCompanyDetails CompanyDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonMarketplaceDetails MarketplaceDetails { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties ProjectProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails UserDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonProjectProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties>
    {
        public NeonProjectProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attribute { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonBranchProperties Branch { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonDatabaseProperties> Databases { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.DefaultEndpointSettings DefaultEndpointSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonEndpointProperties> Endpoints { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public int? HistoryRetention { get { throw null; } set { } }
        public int? PostgresVersion { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        public string RegionId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties> Roles { get { throw null; } }
        public long? Storage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonProjectProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeonResourceProvisioningState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeonResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState left, Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonRole : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRole>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRole>
    {
        internal NeonRole() { }
        public Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonRole System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRole>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRole>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonRole System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRole>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRole>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRole>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonRoleProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>
    {
        public NeonRoleProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NeonPostgres.Models.Attributes> Attributes { get { throw null; } }
        public string BranchId { get { throw null; } set { } }
        public string CreatedAt { get { throw null; } }
        public string EntityId { get { throw null; } }
        public string EntityName { get { throw null; } set { } }
        public bool? IsSuperUser { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Permissions { get { throw null; } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonResourceProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonRoleProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NeonSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>
    {
        public NeonSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public string SingleSignOnUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NeonSingleSignOnState : System.IEquatable<Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NeonSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState left, Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NeonUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>
    {
        public NeonUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.NeonUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>
    {
        public PartnerOrganizationProperties(string organizationName) { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.NeonPostgres.Models.NeonSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PartnerOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PgVersion : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>
    {
        public PgVersion() { }
        public int? Version { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PgVersionsResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>
    {
        internal PgVersionsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NeonPostgres.Models.PgVersion> Versions { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NeonPostgres.Models.PgVersionsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
