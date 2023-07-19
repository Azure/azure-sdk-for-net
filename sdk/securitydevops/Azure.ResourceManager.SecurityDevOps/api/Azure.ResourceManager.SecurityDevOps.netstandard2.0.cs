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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsConnectorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public AzureDevOpsConnectorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorProperties Properties { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsOrgResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsOrgData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureDevOpsOrgData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgProperties Properties { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsProjectResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsProjectData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureDevOpsProjectData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectProperties Properties { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.AzureDevOpsRepoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AzureDevOpsRepoData : Azure.ResourceManager.Models.ResourceData
    {
        public AzureDevOpsRepoData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsRepoProperties Properties { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GitHubConnectorData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public GitHubConnectorData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorProperties Properties { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubOwnerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GitHubOwnerData : Azure.ResourceManager.Models.ResourceData
    {
        public GitHubOwnerData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubOwnerProperties Properties { get { throw null; } set { } }
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
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SecurityDevOps.GitHubRepoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GitHubRepoData : Azure.ResourceManager.Models.ResourceData
    {
        public GitHubRepoData() { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubRepoProperties Properties { get { throw null; } set { } }
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
namespace Azure.ResourceManager.SecurityDevOps.Models
{
    public partial class ActionableRemediation
    {
        public ActionableRemediation() { }
        public System.Collections.Generic.IList<string> BranchNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationRuleCategory> Categories { get { throw null; } }
        public System.Collections.Generic.IList<string> SeverityLevels { get { throw null; } }
        public Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediationState? State { get { throw null; } set { } }
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
    public partial class AzureDevOpsConnectorProperties
    {
        public AzureDevOpsConnectorProperties() { }
        public string AuthorizationCode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsOrgMetadata> Orgs { get { throw null; } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class AzureDevOpsConnectorStats : Azure.ResourceManager.Models.ResourceData
    {
        public AzureDevOpsConnectorStats() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsConnectorStatsProperties Properties { get { throw null; } set { } }
    }
    public partial class AzureDevOpsConnectorStatsProperties
    {
        public AzureDevOpsConnectorStatsProperties() { }
        public long? OrgsCount { get { throw null; } set { } }
        public long? ProjectsCount { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public long? ReposCount { get { throw null; } set { } }
    }
    public partial class AzureDevOpsOrgMetadata
    {
        public AzureDevOpsOrgMetadata() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityDevOps.Models.AzureDevOpsProjectMetadata> Projects { get { throw null; } }
    }
    public partial class AzureDevOpsOrgProperties
    {
        public AzureDevOpsOrgProperties() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class AzureDevOpsProjectMetadata
    {
        public AzureDevOpsProjectMetadata() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Repos { get { throw null; } }
    }
    public partial class AzureDevOpsProjectProperties
    {
        public AzureDevOpsProjectProperties() { }
        public Azure.ResourceManager.SecurityDevOps.Models.AutoDiscovery? AutoDiscovery { get { throw null; } set { } }
        public string OrgName { get { throw null; } set { } }
        public string ProjectId { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class AzureDevOpsRepoProperties
    {
        public AzureDevOpsRepoProperties() { }
        public Azure.ResourceManager.SecurityDevOps.Models.ActionableRemediation ActionableRemediation { get { throw null; } set { } }
        public string OrgName { get { throw null; } set { } }
        public string ProjectName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string RepoId { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
        public string Visibility { get { throw null; } set { } }
    }
    public partial class GitHubConnectorProperties
    {
        public GitHubConnectorProperties() { }
        public string Code { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class GitHubConnectorStats : Azure.ResourceManager.Models.ResourceData
    {
        public GitHubConnectorStats() { }
        public Azure.ResourceManager.SecurityDevOps.Models.GitHubConnectorStatsProperties Properties { get { throw null; } set { } }
    }
    public partial class GitHubConnectorStatsProperties
    {
        public GitHubConnectorStatsProperties() { }
        public long? OwnersCount { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public long? ReposCount { get { throw null; } set { } }
    }
    public partial class GitHubOwnerProperties
    {
        public GitHubOwnerProperties() { }
        public System.Uri OwnerUri { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class GitHubRepoProperties
    {
        public GitHubRepoProperties() { }
        public long? AccountId { get { throw null; } set { } }
        public string OwnerName { get { throw null; } set { } }
        public Azure.ResourceManager.SecurityDevOps.Models.ProvisioningState? ProvisioningState { get { throw null; } set { } }
        public System.Uri RepoUri { get { throw null; } set { } }
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
