namespace Azure.Developer.DevCenter
{
    public partial class DevBoxesClient
    {
        protected DevBoxesClient() { }
        public DevBoxesClient(System.Uri endpoint, string projectName, Azure.Core.TokenCredential credential) { }
        public DevBoxesClient(System.Uri endpoint, string projectName, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateDevBox(Azure.WaitUntil waitUntil, string userId, string devBoxName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateDevBoxAsync(Azure.WaitUntil waitUntil, string userId, string devBoxName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DelayUpcomingAction(string userId, string devBoxName, string upcomingActionId, System.DateTimeOffset delayUntil, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DelayUpcomingActionAsync(string userId, string devBoxName, string upcomingActionId, System.DateTimeOffset delayUntil, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteDevBox(Azure.WaitUntil waitUntil, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteDevBoxAsync(Azure.WaitUntil waitUntil, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDevBoxByUser(string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDevBoxByUserAsync(string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevBoxesByUser(string userId, string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevBoxesByUserAsync(string userId, string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetPool(string poolName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPoolAsync(string poolName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPools(int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolsAsync(int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRemoteConnection(string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRemoteConnectionAsync(string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetScheduleByPool(string poolName, string scheduleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleByPoolAsync(string poolName, string scheduleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedulesByPool(string poolName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesByPoolAsync(string poolName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetUpcomingAction(string userId, string devBoxName, string upcomingActionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetUpcomingActionAsync(string userId, string devBoxName, string upcomingActionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetUpcomingActions(string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetUpcomingActionsAsync(string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SkipUpcomingAction(string userId, string devBoxName, string upcomingActionId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SkipUpcomingActionAsync(string userId, string devBoxName, string upcomingActionId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation StartDevBox(Azure.WaitUntil waitUntil, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> StartDevBoxAsync(Azure.WaitUntil waitUntil, string userId, string devBoxName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation StopDevBox(Azure.WaitUntil waitUntil, string userId, string devBoxName, bool? hibernate = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> StopDevBoxAsync(Azure.WaitUntil waitUntil, string userId, string devBoxName, bool? hibernate = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevCenterClient
    {
        protected DevCenterClient() { }
        public DevCenterClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DevCenterClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxes(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesAsync(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxesByUser(string userId, string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesByUserAsync(string userId, string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevCenterClientOptions : Azure.Core.ClientOptions
    {
        public DevCenterClientOptions(Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion version = Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion.V2022_11_11_Preview) { }
        public enum ServiceVersion
        {
            V2022_11_11_Preview = 1,
        }
    }
    public partial class EnvironmentsClient
    {
        protected EnvironmentsClient() { }
        public EnvironmentsClient(System.Uri endpoint, string projectName, Azure.Core.TokenCredential credential) { }
        public EnvironmentsClient(System.Uri endpoint, string projectName, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateEnvironment(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateEnvironmentAsync(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation CustomEnvironmentAction(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CustomEnvironmentActionAsync(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeleteEnvironment(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteEnvironmentAsync(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation DeployEnvironmentAction(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeployEnvironmentActionAsync(Azure.WaitUntil waitUntil, string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCatalogItem(string catalogItemId, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCatalogItemAsync(string catalogItemId, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCatalogItems(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCatalogItemsAsync(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCatalogItemVersion(string catalogItemId, string version, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCatalogItemVersionAsync(string catalogItemId, string version, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCatalogItemVersions(string catalogItemId, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCatalogItemVersionsAsync(string catalogItemId, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnvironmentByUser(string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentByUserAsync(string userId, string environmentName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironments(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentsAsync(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentsByUser(string userId, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentsByUserAsync(string userId, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentTypes(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentTypesAsync(int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateEnvironment(string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateEnvironmentAsync(string userId, string environmentName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class DevCenterClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevBoxesClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevBoxesClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevBoxesClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevBoxesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevCenterClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevCenterClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevCenterClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevCenterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.EnvironmentsClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddEnvironmentsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.EnvironmentsClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddEnvironmentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
