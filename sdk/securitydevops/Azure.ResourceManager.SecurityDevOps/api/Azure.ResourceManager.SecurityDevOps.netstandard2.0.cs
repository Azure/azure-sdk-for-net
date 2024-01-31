namespace Azure.ResourceManager.SecurityDevOps
{
    public partial class AzureDevOpsConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>, System.Collections.IEnumerable
    {
        protected AzureDevOpsConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureDevOpsConnectorName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureDevOpsConnectorName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> Get(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> GetAsync(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetIfExists(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> GetIfExistsAsync(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsConnectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData>
    {
        public AzureDevOpsConnectorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureDevOpsConnectorResource() { }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureDevOpsConnectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats> GetAzureDevOpsConnectorStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats> GetAzureDevOpsConnectorStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> GetAzureDevOpsOrg(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>> GetAzureDevOpsOrgAsync(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgCollection GetAzureDevOpsOrgs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> GetAzureDevOpsReposByConnector(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> GetAzureDevOpsReposByConnectorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureDevOpsOrgCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>, System.Collections.IEnumerable
    {
        protected AzureDevOpsOrgCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureDevOpsOrgName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureDevOpsOrgName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> Get(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>> GetAsync(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> GetIfExists(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>> GetIfExistsAsync(string azureDevOpsOrgName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsOrgData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData>
    {
        public AzureDevOpsOrgData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsOrgResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureDevOpsOrgResource() { }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureDevOpsConnectorName, string azureDevOpsOrgName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> GetAzureDevOpsProject(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>> GetAzureDevOpsProjectAsync(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectCollection GetAzureDevOpsProjects() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureDevOpsProjectCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>, System.Collections.IEnumerable
    {
        protected AzureDevOpsProjectCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureDevOpsProjectName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureDevOpsProjectName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> Get(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>> GetAsync(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> GetIfExists(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>> GetIfExistsAsync(string azureDevOpsProjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsProjectData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData>
    {
        public AzureDevOpsProjectData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsProjectResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureDevOpsProjectResource() { }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureDevOpsConnectorName, string azureDevOpsOrgName, string azureDevOpsProjectName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> GetAzureDevOpsRepo(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>> GetAzureDevOpsRepoAsync(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoCollection GetAzureDevOpsRepos() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureDevOpsRepoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>, System.Collections.IEnumerable
    {
        protected AzureDevOpsRepoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string azureDevOpsRepoName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string azureDevOpsRepoName, Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> Get(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>> GetAsync(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> GetIfExists(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>> GetIfExistsAsync(string azureDevOpsRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsRepoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData>
    {
        public AzureDevOpsRepoData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsRepoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AzureDevOpsRepoResource() { }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string azureDevOpsConnectorName, string azureDevOpsOrgName, string azureDevOpsProjectName, string azureDevOpsRepoName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GitHubConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>, System.Collections.IEnumerable
    {
        protected GitHubConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gitHubConnectorName, Azure.ResourceManager.SecurityDevOps.GitHubConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gitHubConnectorName, Azure.ResourceManager.SecurityDevOps.GitHubConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> Get(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> GetAsync(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetIfExists(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> GetIfExistsAsync(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GitHubConnectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubConnectorData>
    {
        public GitHubConnectorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.GitHubConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.GitHubConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubConnectorResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GitHubConnectorResource() { }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gitHubConnectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats> GetGitHubConnectorStats(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats> GetGitHubConnectorStatsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> GetGitHubOwner(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>> GetGitHubOwnerAsync(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubOwnerCollection GetGitHubOwners() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> GetGitHubReposByConnector(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> GetGitHubReposByConnectorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.GitHubConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.GitHubConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GitHubOwnerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>, System.Collections.IEnumerable
    {
        protected GitHubOwnerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gitHubOwnerName, Azure.ResourceManager.SecurityDevOps.GitHubOwnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gitHubOwnerName, Azure.ResourceManager.SecurityDevOps.GitHubOwnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> Get(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>> GetAsync(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> GetIfExists(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>> GetIfExistsAsync(string gitHubOwnerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GitHubOwnerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubOwnerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubOwnerData>
    {
        public GitHubOwnerData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.GitHubOwnerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubOwnerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubOwnerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.GitHubOwnerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubOwnerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubOwnerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubOwnerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubOwnerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GitHubOwnerResource() { }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubOwnerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gitHubConnectorName, string gitHubOwnerName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> GetGitHubRepo(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>> GetGitHubRepoAsync(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubRepoCollection GetGitHubRepos() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.GitHubOwnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.GitHubOwnerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GitHubRepoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>, System.Collections.IEnumerable
    {
        protected GitHubRepoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string gitHubRepoName, Azure.ResourceManager.SecurityDevOps.GitHubRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string gitHubRepoName, Azure.ResourceManager.SecurityDevOps.GitHubRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> Get(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>> GetAsync(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> GetIfExists(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>> GetIfExistsAsync(string gitHubRepoName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GitHubRepoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubRepoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubRepoData>
    {
        public GitHubRepoData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.GitHubRepoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubRepoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.GitHubRepoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.GitHubRepoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubRepoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubRepoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.GitHubRepoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubRepoResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GitHubRepoResource() { }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubRepoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gitHubConnectorName, string gitHubOwnerName, string gitHubRepoName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.GitHubRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SecurityDevOps.GitHubRepoData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class SecurityDevOpsExtensions
    {
        public static Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAzureDevOpsConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> GetAzureDevOpsConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource GetAzureDevOpsConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorCollection GetAzureDevOpsConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAzureDevOpsConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAzureDevOpsConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource GetAzureDevOpsOrgResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource GetAzureDevOpsProjectResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource GetAzureDevOpsRepoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetGitHubConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> GetGitHubConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource GetGitHubConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.GitHubConnectorCollection GetGitHubConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetGitHubConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetGitHubConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource GetGitHubOwnerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.GitHubRepoResource GetGitHubRepoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.SecurityDevOps.Mocking
{
    public partial class MockableSecurityDevOpsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSecurityDevOpsArmClient() { }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource GetAzureDevOpsConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource GetAzureDevOpsOrgResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource GetAzureDevOpsProjectResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource GetAzureDevOpsRepoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource GetGitHubConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource GetGitHubOwnerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubRepoResource GetGitHubRepoResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSecurityDevOpsResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSecurityDevOpsResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAzureDevOpsConnector(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>> GetAzureDevOpsConnectorAsync(string azureDevOpsConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorCollection GetAzureDevOpsConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetGitHubConnector(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>> GetGitHubConnectorAsync(string gitHubConnectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SecurityDevOps.GitHubConnectorCollection GetGitHubConnectors() { throw null; }
    }
    public partial class MockableSecurityDevOpsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSecurityDevOpsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAzureDevOpsConnectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> GetAzureDevOpsConnectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetGitHubConnectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> GetGitHubConnectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SecurityDevOps.Models
{
    public partial class ActionableRemediation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation>
    {
        public ActionableRemediation() { }
        public System.Collections.Generic.IList<string> BranchNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> SeverityLevels { get { throw null; } }
        public Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState? State { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionableRemediationRuleCategory : System.IEquatable<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionableRemediationRuleCategory(string value) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory Artifacts { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory Code { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory Containers { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory Dependencies { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory InfrastructureAsCode { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory Secrets { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory left, Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory left, Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionableRemediationState : System.IEquatable<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionableRemediationState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState Disabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState Enabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState left, Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState left, Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmSecurityDevOpsModelFactory
    {
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorData AzureDevOpsConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats AzureDevOpsConnectorStats(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgData AzureDevOpsOrgData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectData AzureDevOpsProjectData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoData AzureDevOpsRepoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.GitHubConnectorData GitHubConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats GitHubConnectorStats(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.GitHubOwnerData GitHubOwnerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.GitHubRepoData GitHubRepoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties properties = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoDiscovery : System.IEquatable<Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoDiscovery(string value) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery Disabled { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery left, Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery left, Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureDevOpsConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties>
    {
        public AzureDevOpsConnectorProperties() { }
        public string AuthorizationCode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata> Orgs { get { throw null; } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsConnectorStats : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats>
    {
        public AzureDevOpsConnectorStats() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsConnectorStatsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties>
    {
        public AzureDevOpsConnectorStatsProperties() { }
        public long? OrgsCount { get { throw null; } set { } }
        public long? ProjectsCount { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public long? ReposCount { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsOrgMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata>
    {
        public AzureDevOpsOrgMetadata() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata> Projects { get { throw null; } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsOrgProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties>
    {
        public AzureDevOpsOrgProperties() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsProjectMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata>
    {
        public AzureDevOpsProjectMetadata() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Repos { get { throw null; } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsProjectProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties>
    {
        public AzureDevOpsProjectProperties() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public string OrgName { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureDevOpsRepoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties>
    {
        public AzureDevOpsRepoProperties() { }
        public Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public string OrgName { get { throw null; } set { } }
        public string ProjectName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RepoId { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
        public string Visibility { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties>
    {
        public GitHubConnectorProperties() { }
        public string Code { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubConnectorStats : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats>
    {
        public GitHubConnectorStats() { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStats>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubConnectorStatsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties>
    {
        public GitHubConnectorStatsProperties() { }
        public long? OwnersCount { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public long? ReposCount { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubOwnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties>
    {
        public GitHubOwnerProperties() { }
        public System.Uri OwnerUri { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GitHubRepoProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties>
    {
        public GitHubRepoProperties() { }
        public long? AccountId { get { throw null; } set { } }
        public string OwnerName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState left, Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState left, Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
