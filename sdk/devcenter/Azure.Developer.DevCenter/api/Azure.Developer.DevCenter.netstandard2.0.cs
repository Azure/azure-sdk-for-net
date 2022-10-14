namespace Azure.Developer.DevCenter
{
    public partial class DevBoxesClient
    {
        protected DevBoxesClient() { }
        public DevBoxesClient(string tenantId, string devCenter, string projectName, Azure.Core.TokenCredential credential) { }
        public DevBoxesClient(string tenantId, string devCenter, string projectName, Azure.Core.TokenCredential credential, string devCenterDnsSuffix, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateDevBox(Azure.WaitUntil waitUntil, string devBoxName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateDevBoxAsync(Azure.WaitUntil waitUntil, string devBoxName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteDevBox(Azure.WaitUntil waitUntil, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteDevBoxAsync(Azure.WaitUntil waitUntil, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDevBoxByUser(string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDevBoxByUserAsync(string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevBoxesByUser(string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevBoxesByUserAsync(string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetPool(string poolName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPoolAsync(string poolName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPools(int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolsAsync(int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRemoteConnection(string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRemoteConnectionAsync(string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetScheduleByPool(string poolName, string scheduleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleByPoolAsync(string poolName, string scheduleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedulesByPool(string poolName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesByPoolAsync(string poolName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> StartDevBox(Azure.WaitUntil waitUntil, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> StartDevBoxAsync(Azure.WaitUntil waitUntil, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Stop(Azure.WaitUntil waitUntil, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> StopAsync(Azure.WaitUntil waitUntil, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevCenterClient
    {
        protected DevCenterClient() { }
        public DevCenterClient(string tenantId, string devCenter, Azure.Core.TokenCredential credential) { }
        public DevCenterClient(string tenantId, string devCenter, Azure.Core.TokenCredential credential, string devCenterDnsSuffix, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxes(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesAsync(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxesByUser(string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesByUserAsync(string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevCenterClientOptions : Azure.Core.ClientOptions
    {
        public DevCenterClientOptions(Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion version = Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion.V2022_03_01_Preview) { }
        public enum ServiceVersion
        {
            V2022_03_01_Preview = 1,
        }
    }
    public partial class EnvironmentsClient
    {
        protected EnvironmentsClient() { }
        public EnvironmentsClient(string tenantId, string devCenter, string projectName, Azure.Core.TokenCredential credential) { }
        public EnvironmentsClient(string tenantId, string devCenter, string projectName, Azure.Core.TokenCredential credential, string devCenterDnsSuffix, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateEnvironment(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateEnvironmentAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CustomEnvironmentAction(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CustomEnvironmentActionAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteEnvironment(Azure.WaitUntil waitUntil, string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteEnvironmentAction(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteEnvironmentActionAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteEnvironmentAsync(Azure.WaitUntil waitUntil, string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployEnvironmentAction(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployEnvironmentActionAsync(Azure.WaitUntil waitUntil, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetArtifactsByEnvironment(string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetArtifactsByEnvironmentAndPath(string environmentName, string artifactPath, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetArtifactsByEnvironmentAndPathAsync(string environmentName, string artifactPath, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetArtifactsByEnvironmentAsync(string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCatalogItem(string catalogItemId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCatalogItemAsync(string catalogItemId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCatalogItems(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCatalogItemsAsync(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCatalogItemVersion(string catalogItemId, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCatalogItemVersionAsync(string catalogItemId, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCatalogItemVersions(string catalogItemId, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCatalogItemVersionsAsync(string catalogItemId, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnvironmentByUser(string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentByUserAsync(string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironments(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentsAsync(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentsByUser(string userId = "me", int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentsByUserAsync(string userId = "me", int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentTypes(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentTypesAsync(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateEnvironment(string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateEnvironmentAsync(string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
    }
}
