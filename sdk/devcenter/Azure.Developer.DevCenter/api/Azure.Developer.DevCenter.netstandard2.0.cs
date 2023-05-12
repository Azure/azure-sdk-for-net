namespace Azure.Developer.DevCenter
{
    public partial class DeploymentEnvironmentsClient
    {
        protected DeploymentEnvironmentsClient() { }
        public DeploymentEnvironmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DeploymentEnvironmentsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdateEnvironment(Azure.WaitUntil waitUntil, string projectName, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string environmentName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteEnvironment(Azure.WaitUntil waitUntil, string projectName, string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteEnvironmentAsync(Azure.WaitUntil waitUntil, string projectName, string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllEnvironments(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllEnvironmentsAsync(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetCatalog(string projectName, string catalogName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetCatalogAsync(string projectName, string catalogName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetCatalogs(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetCatalogsAsync(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnvironment(string projectName, string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentAsync(string projectName, string environmentName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEnvironmentDefinition(string projectName, string catalogName, string definitionName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEnvironmentDefinitionAsync(string projectName, string catalogName, string definitionName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentDefinitions(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentDefinitionsAsync(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentDefinitionsByCatalog(string projectName, string catalogName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentDefinitionsByCatalogAsync(string projectName, string catalogName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironments(string projectName, string userId = "me", int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentsAsync(string projectName, string userId = "me", int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEnvironmentTypes(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEnvironmentTypesAsync(string projectName, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevBoxesClient
    {
        protected DevBoxesClient() { }
        public DevBoxesClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DevBoxesClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CreateDevBox(Azure.WaitUntil waitUntil, string projectName, string devBoxName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string devBoxName, Azure.Core.RequestContent content, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DelayAction(string projectName, string devBoxName, string actionName, System.DateTimeOffset until, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DelayActionAsync(string projectName, string devBoxName, string actionName, System.DateTimeOffset until, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> DelayAllActions(string projectName, string devBoxName, System.DateTimeOffset until, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> DelayAllActionsAsync(string projectName, string devBoxName, System.DateTimeOffset until, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> DeleteDevBox(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetAction(string projectName, string devBoxName, string actionName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetActionAsync(string projectName, string devBoxName, string actionName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetActions(string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetActionsAsync(string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxes(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesAsync(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAllDevBoxesByUser(string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllDevBoxesByUserAsync(string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetDevBox(string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDevBoxAsync(string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetDevBoxes(string projectName, string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetDevBoxesAsync(string projectName, string userId = "me", string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetPool(string projectName, string poolName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetPoolAsync(string projectName, string poolName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetPools(string projectName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetPoolsAsync(string projectName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetRemoteConnection(string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRemoteConnectionAsync(string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetSchedule(string projectName, string poolName, string scheduleName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleAsync(string projectName, string poolName, string scheduleName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedules(string projectName, string poolName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesAsync(string projectName, string poolName, int? maxCount = default(int?), string filter = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> RestartDevBox(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> RestartDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response SkipAction(string projectName, string devBoxName, string actionName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SkipActionAsync(string projectName, string devBoxName, string actionName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> StartDevBox(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> StartDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> StopDevBox(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", bool? hibernate = default(bool?), Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> StopDevBoxAsync(Azure.WaitUntil waitUntil, string projectName, string devBoxName, string userId = "me", bool? hibernate = default(bool?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevCenterClient
    {
        protected DevCenterClient() { }
        public DevCenterClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public DevCenterClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.Developer.DevCenter.DevCenterClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetProject(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetProjectAsync(string projectName, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetProjects(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetProjectsAsync(string filter = null, int? maxCount = default(int?), Azure.RequestContext context = null) { throw null; }
    }
    public partial class DevCenterClientOptions : Azure.Core.ClientOptions
    {
        public DevCenterClientOptions(Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion version = Azure.Developer.DevCenter.DevCenterClientOptions.ServiceVersion.V2023_04_01) { }
        public enum ServiceVersion
        {
            V2023_04_01 = 1,
        }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class DevCenterClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DeploymentEnvironmentsClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDeploymentEnvironmentsClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DeploymentEnvironmentsClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDeploymentEnvironmentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevBoxesClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevBoxesClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevBoxesClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevBoxesClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevCenterClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevCenterClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Developer.DevCenter.DevCenterClient, Azure.Developer.DevCenter.DevCenterClientOptions> AddDevCenterClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
